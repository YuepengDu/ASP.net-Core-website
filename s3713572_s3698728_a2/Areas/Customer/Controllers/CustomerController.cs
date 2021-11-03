using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using s3713572_s3698728_a2.Data;
using s3713572_s3698728_a2.Models;
/*using s3713572_s3698728_a2.Utilities;*/
using s3713572_s3698728_a2.Filters;
using static s3713572_s3698728_a2.Models.Transaction;
using Microsoft.EntityFrameworkCore;

namespace s3713572_s3698728_a2.Controllers
{
    [AuthorizeCustomer]
    [Area("Customer")]
    public class CustomerController : Controller
    {
        private readonly BankContext _context;

        // ReSharper disable once PossibleInvalidOperationException
        private int CustomerID => HttpContext.Session.GetInt32(nameof(Customer.CustomerID)).Value;

        public CustomerController(BankContext context) => _context = context;
        //Get all customer
        public async Task<IActionResult> Index()
        {
            // Eager loading.
            var customer = await _context.Customer.Include(x => x.Accounts).
                FirstOrDefaultAsync(x => x.CustomerID == CustomerID);

            return View(customer);
        }
        //return all accounts for the customer
        public async Task<IActionResult> ATMAccountSelection()
        {
            var customer = await _context.Customer.Include(x => x.Accounts).
            FirstOrDefaultAsync(x => x.CustomerID == CustomerID);
            return View(customer);
        }

        public async Task<IActionResult> Deposit(int id) => View(await _context.Account.FindAsync(id));

        /// <summary>
        /// For user to deposit into account with positive value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Deposit(int id, decimal amount)
        {
            var account = await _context.Account.FindAsync(id);

            if (amount <= 0)
                ModelState.AddModelError(nameof(amount), "Amount must be positive.");
           
            if (!ModelState.IsValid)
            {
                ViewBag.Amount = amount;
                return View(account);
            }

            //Add balance and add transaction record in database
            account.Balance += amount;
            account.Transactions.Add(
                new Transaction
                {
                    transactionType = TransactionType.Deposit,
                    Amount = amount,
                    ModifyDate = DateTime.Now
                });

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Withdraw(int id) => View(await _context.Account.FindAsync(id));
        /// <summary>
        /// For user to withdraw money with conditions based on the account type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Withdraw(int id, decimal amount)
        {
            var account = await _context.Account.FindAsync(id);

            if (amount <= 0)
                ModelState.AddModelError(nameof(amount), "Amount must be positive.");
            if (!ModelState.IsValid)
            {
                ViewBag.Amount = amount;
                return View(account);
            }

            // For saving account, no less than 0 dollar in account
            if (account.AccountType == AccountType.Saving)
            {
                if (account.Balance < amount)
                {
                    ModelState.AddModelError(nameof(amount), "You don't have enough money.");
                    return View(account);
                }
                else
                {
                    if (HasFreeChance(account.AccountNumber).Result)
                    {
                        account.Balance -= amount;
                        account.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.Withdraw,
                                Amount = amount,
                                ModifyDate = DateTime.Now
                            });
                    }
                    else
                    {
                        account.Balance -= amount + (decimal)0.1;
                        account.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.Withdraw,
                                Amount = amount,
                                ModifyDate = DateTime.Now
                            });
                        //Add service charge in transaction
                        account.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.ServiceCharge,
                                Amount = (decimal)0.1,
                                Comment = "Service Fee",
                                ModifyDate = DateTime.Now
                            });
                    }
                    
                }
            }
            // For checking account, no less than 200 dollar in account
            if (account.AccountType == AccountType.Checking)
            {
                if (account.Balance + 200 < amount)
                {
                    ModelState.AddModelError(nameof(amount), "You don't have enough money.");
                    return View(account);
                }
                else
                {
                    if (!HasFreeChance(account.AccountNumber).Result)
                    {
                        account.Balance -= amount;
                        account.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.Withdraw,
                                Amount = amount,
                                ModifyDate = DateTime.Now
                            });
                    }
                    else
                    {
                        account.Balance -= amount + (decimal)0.1;
                        account.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.Withdraw,
                                Amount = amount,
                                ModifyDate = DateTime.Now
                            });
                        //Add service charge in transaction
                        account.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.ServiceCharge,
                                Amount = (decimal)0.1,
                                Comment = "Service Fee",
                                ModifyDate = DateTime.Now
                            });
                    }
                }
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> TransferFromAccountSelection() => View(await _context.Customer.FindAsync(CustomerID));

        public IActionResult Transfer() => View();
        
        [HttpPost]
        public async Task<IActionResult> Transfer(decimal amount, int id, int destinationId, string comment)
        {
            var acc = await _context.Account.FindAsync(id);
            var destinationAcc = await _context.Account.FindAsync(destinationId);
            //Null account checker
            if(destinationAcc == null)
            {
                ModelState.AddModelError(nameof(destinationId), "The Destination account was not found");
            }
            //You can not transfer to the same account !
            if(id == destinationId)
            {
                ModelState.AddModelError(nameof(destinationId), "You can not transfer to the same account");
            }
            //No negative value allows
            if (amount <= 0)
                ModelState.AddModelError(nameof(amount), "Amount must be positive.");

            if (!ModelState.IsValid)
            {
                ViewBag.Amount = amount;
                return View(acc); 
            }
            
            // Applying business rules, minimum amount in saving is 0 and 200 for checking
            if (acc.AccountType == AccountType.Saving)
            {
                if (acc.Balance < amount)
                {
                    ModelState.AddModelError(nameof(amount), "You don't have enough money.");
                    return View(acc);
                }
                else
                {
                    if (HasFreeChance(acc.AccountNumber).Result)
                    {
                        acc.Balance -= amount;
                        destinationAcc.Balance += amount;
                        acc.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.Transfer,
                                Amount = amount,
                                DestAccount = destinationId,
                                ModifyDate = DateTime.Now
                            });
                        destinationAcc.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.Transfer,
                                Amount = amount,
                                AccountNumber = destinationId,
                                ModifyDate = DateTime.Now
                            });
                    }
                    else
                    {
                        acc.Balance -= amount + (decimal)0.2;
                        destinationAcc.Balance += amount;
                        acc.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.Transfer,
                                Amount = amount,
                                DestAccount = destinationId,
                                ModifyDate = DateTime.Now
                            });
                        //Add Service Charge to transaction
                        acc.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.ServiceCharge,
                                Amount = (decimal)0.20,
                                Comment = "Service Fee",
                                ModifyDate = DateTime.Now
                            });
                        destinationAcc.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.Transfer,
                                Amount = amount,
                                AccountNumber = destinationId,
                                ModifyDate = DateTime.Now
                            });
                    }
                    
                }
            }

            if (acc.AccountType == AccountType.Checking)
            {
                if (acc.Balance + 200 < amount)
                {
                    ModelState.AddModelError(nameof(amount), "You don't have enough money.");
                    return View(acc);
                }
                else
                {
                    if (HasFreeChance(acc.AccountNumber).Result)
                    {
                        acc.Balance -= amount;
                        destinationAcc.Balance += amount;
                        acc.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.Transfer,
                                Amount = amount,
                                DestAccount = destinationId,
                                ModifyDate = DateTime.Now
                            });
                        destinationAcc.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.Transfer,
                                Amount = amount,
                                AccountNumber = destinationId,
                                ModifyDate = DateTime.Now
                            });
                    }
                    else
                    {
                        acc.Balance -= amount + (decimal)0.2;
                        destinationAcc.Balance += amount;
                        acc.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.Transfer,
                                Amount = amount,
                                DestAccount = destinationId,
                                ModifyDate = DateTime.Now
                            });
                        //Add Service Charge to transaction
                        acc.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.ServiceCharge,
                                Amount = (decimal)0.20,
                                Comment = "Service Fee",
                                ModifyDate = DateTime.Now
                            });
                        destinationAcc.Transactions.Add(
                            new Transaction
                            {
                                transactionType = TransactionType.Transfer,
                                Amount = amount,
                                AccountNumber = destinationId,
                                ModifyDate = DateTime.Now
                            });
                    }
                }
            }


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

       

        public async Task<IActionResult> StatementSelection()
        {
            var customer = await _context.Customer.FindAsync(CustomerID);

            return View(customer);
        }
        /// <summary>
        /// Each user have 4 free transcation without service charge per account
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public async Task<bool> HasFreeChance(int accountNumber)
        {
            var account = await _context.Account.FindAsync(accountNumber);
            int count = 0;
            foreach(Transaction transaction in account.Transactions)
            {
                if (transaction.transactionType == TransactionType.Transfer || transaction.transactionType == TransactionType.Withdraw)
                {
                    count++;
                }
            }
            if (count < 4)
            {
                return true;
            }

            return false;
        }



    }
}
