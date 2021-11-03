using s3713572_s3698728_a2.Data;
using s3713572_s3698728_a2.Filters;
using s3713572_s3698728_a2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s3713572_s3698728_a2.Controllers
{
    [AuthorizeCustomer]
    [Area("Customer")]
    public class BillPayController : Controller
    {
        private readonly BankContext _context;
        private int CustomerID => HttpContext.Session.GetInt32(nameof(Customer.CustomerID)).Value; //get CustomerID from session
        public BillPayController(BankContext context)
        {
            _context = context;
        }
        //Get Bills
        public async Task<IActionResult> Index()
        {
            var customer = await _context.Customer.FindAsync(CustomerID);
            return View(customer);
        }
        //Add payment
        public async Task<IActionResult> AddPayment(int? id)
        {

            ViewBag.Payees = _context.Payee.ToList();
            return View(await _context.Account.FindAsync(id));
            
        }

        [HttpPost]
        public async Task<IActionResult> AddPayment(int? id, int PayeeID, decimal Amount, DateTime ScheduleDate, Period Period)
        {
            var account = await _context.Account.FindAsync(id);
            if (await InsertPayment(id, PayeeID, Amount, ScheduleDate, Period))
            {
                return RedirectToAction("Index", "BillPay");
            }
            else
            {
                ViewBag.Payees = _context.Payee.ToList();
                ViewBag.Amount = Amount;
                return View(account);
            }
        }
        /// <summary>
        /// We receive values from the front-end and do the insert into database of bills with conditions
        /// </summary>
        /// <param name="id"></param>
        /// <param name="PayeeID"></param>
        /// <param name="Amount"></param>
        /// <param name="ScheduleDate"></param>
        /// <param name="Period"></param>
        /// <returns></returns>
        public async Task<bool> InsertPayment(int? id, int PayeeID, decimal Amount, DateTime ScheduleDate, Period Period)
        {
            Account account = await _context.Account.FindAsync(id);
            if (Amount <= 0)
                ModelState.AddModelError(nameof(Amount), "Amount must be positive.");
            if (account.Balance < Amount)
                ModelState.AddModelError(nameof(Amount), "Your account balance is not enough.");
            
            if (ScheduleDate < DateTime.Now)
            {
                ModelState.AddModelError("ScheduleDate", "Schedule Date cannot be ealier than today");
            }
            if (!ModelState.IsValid)
            {

                return false;
            }
            BillPay billPay = new BillPay
            {
                AccountNumber = (int)id,
                PayeeID = PayeeID,
                Amount = Amount,
                ModifyDate = DateTime.Now, //default modfied today
                ScheduleDate = ScheduleDate.ToUniversalTime(),
                Period = Period
            };
            _context.BillPay.Add(billPay);
            _context.SaveChanges();

            return true;
        }
        //Get all payments for current customer
        public async Task<IActionResult> PaymentList(int? id, int pageNumber = 1)
        {
            var account = await _context.Account.FindAsync(id);

            ViewBag.AccountNumber = id;

            return View(await PaginatedList<BillPay>.CreateAsync(_context.BillPay.Where(x => x.AccountNumber == id), pageNumber, 4));
        }

        public async Task<IActionResult> Modify(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var bill = await _context.BillPay.FindAsync(id);
            ViewBag.ModifyDate = DateTime.Now;
            ViewBag.Payees = _context.Payee.ToList();
            return View(bill);
        }
        /// <summary>
        /// This method allows user to modify a bill with the same conditions when creating it.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="billPay"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modify(int id, [Bind("BillPayId,AccountNumber,PayeeID,Amount,ScheduleDate,Period,ModifyDate")] BillPay billPay)
        {
            if (id != billPay.BillPayId)
            {
                return NotFound();
            }

            if (billPay.Amount <= 0)
                ModelState.AddModelError(nameof(billPay.Amount), "Amount must be positive.");
            if (billPay.ScheduleDate < DateTime.Now)
                ModelState.AddModelError(nameof(billPay.ScheduleDate), "Schedule Date cannot be ealier than today");
            if (!ModelState.IsValid)
            {
                ViewBag.ModifyDate = DateTime.Now;
                ViewBag.Payees = _context.Payee.ToList();
                return View(billPay);
            }
            else
            {
                _context.Update(billPay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



            
        }
        /// <summary>
        /// This method allow user to delete a bill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            var bill = await _context.BillPay.FindAsync(id);
            _context.Remove(bill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool BillPayExists(int id)
        {
            return _context.Payee.Any(e => e.PayeeID == id);
        }



    }
}
