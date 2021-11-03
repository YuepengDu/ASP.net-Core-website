using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using s3713572_s3698728_a2.Data;
using s3713572_s3698728_a2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using static s3713572_s3698728_a2.Models.Transaction;

namespace s3713572_s3698728_a2.BackgroundServices
{
    /// <summary>
    /// This class manage bill pay in background, no matter if we are running the web or not.
    /// It do work automaticly
    /// </summary>
    public class BillPayBackGroundService : BackgroundService
    {
        public string ErrorMsg { get; set; }
        private readonly IServiceProvider _services;
        private readonly ILogger<BillPayBackGroundService> _logger;
        private UdpClient client;
        public IServiceProvider Services { get; }
        public BillPayBackGroundService(IServiceProvider serviceProvider,IServiceProvider services, ILogger<BillPayBackGroundService> logger)
        {
            Services = services;
            _logger = logger;
            _services = serviceProvider;
            
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            client = new UdpClient(888);
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (IServiceScope scope = _services.CreateScope())
                    {
                        var context = scope.ServiceProvider.GetRequiredService<BankContext>();
                        List<BillPay> bills = context.BillPay.ToList();
                        List<Login> Logins = context.Login.ToList();
                        foreach (BillPay bill in bills)
                        {
                            if (bill.ScheduleDate.ToString() == DateTime.Now.ToString() && bill.Block == false)
                            {
                                _logger.LogInformation(
                                          "A bill is due now.");
                                await PayBill(bill, context);
                            }
                        }
                        //Lock the account for 1 minute
                        foreach(Login login in Logins)
                        {
                            if(login.Lock == true && login.LockDate.AddMinutes(1).ToString() == DateTime.Now.ToString())
                            {
                                await Unlock(login, context);
                            }
                        }


                    }
                }
                catch (Exception)
                {
                    await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                }
            }

        }
        /// <summary>
        /// After one minute, the account will be automaticly unlocked.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="_context"></param>
        /// <returns></returns>
        public async Task Unlock(Login login, BankContext _context)
        {
            login.Lock = false;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// For this method we pay the bill based on the date and bill type with conditions
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="_context"></param>
        /// <returns></returns>
        private async Task<bool> PayBill(BillPay bill, BankContext _context)
        {
            var account = await _context.Account.FindAsync(bill.AccountNumber);

            if (account.AccountType == AccountType.Saving && account.Balance >= bill.Amount)
            {
                
                account.Balance -= bill.Amount;
                var payeeName = bill.Payee.PayeeName;
                account.Transactions.Add(
                    new Transaction
                    {
                        transactionType = TransactionType.BillPay,
                        Amount = bill.Amount,
                        Comment= "Paying to "+ payeeName,
                        ModifyDate = DateTime.Now
                    }
                    );
                switch (bill.Period)
                {
                    case Period.Monthly:
                        bill.ScheduleDate = bill.ScheduleDate.AddMonths(1);
                        _context.Update(bill);
                        break;
                    case Period.Quarterly:
                        bill.ScheduleDate = bill.ScheduleDate.AddMonths(3);
                        _context.Update(bill);
                        break;
                    case Period.Once_Off:
                        _context.Remove(bill);
                        break;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            //Checking account must have no less than 200 dollar
            else if(account.AccountType == AccountType.Checking && account.Balance +200 >= bill.Amount)
            {
                account.Balance -= bill.Amount;
                var payeeName = bill.Payee.PayeeName;
                account.Transactions.Add(
                    new Transaction
                    {
                        transactionType = TransactionType.BillPay,
                        Amount = bill.Amount,
                        Comment = "Paying to " + payeeName,
                        ModifyDate = DateTime.Now
                    }
                    );
                switch (bill.Period)
                {
                    case Period.Monthly:
                        bill.ScheduleDate = bill.ScheduleDate.AddMonths(1);
                        _context.Update(bill);
                        break;
                    case Period.Quarterly:
                        bill.ScheduleDate = bill.ScheduleDate.AddMonths(3);
                        _context.Update(bill);
                        break;
                    case Period.Once_Off:
                        _context.Remove(bill);
                        break;
                }
                await _context.SaveChangesAsync();
                return true;
            }else if(account.AccountType == AccountType.Saving && account.Balance <= bill.Amount)
            {
                ErrorMsg = "Your Bill just failed" + bill.BillPayId;
                return false;

            }
            else if(account.AccountType == AccountType.Checking && account.Balance + 200 <= bill.Amount)
            {
                ErrorMsg = "Your Bill just failed" + bill.BillPayId;
                return false;
            }
            return false;
        }

        public override void Dispose()
        {
            if (client != null)
            {
                client.Dispose();
            }
            base.Dispose();
        }
    }
}
