using s3713572_s3698728_a2.UserCategory.Admin.Controllers.Manager;
using s3713572_s3698728_a2.UserCategory.Admin.Filter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace s3713572_s3698728_a2.Areas.Admin.Controllers
{
    [Area("admin")]
    [AuthorizeAdmin]
    public class BillManagerController : Controller
    {
        private BillManager billManager;
        private AccountManager accountManager;

        public BillManagerController()
        {
            billManager = new BillManager();
            accountManager = new AccountManager();
        }

        //Print all bills under this Accountnumber(id)
        public async Task<IActionResult> Index(int? id)
        {
            var bills = await billManager.GetAllBills(id);
            return View(bills);
        }
        
        public async Task<IActionResult> BillPayAccountSelection(int? id)
        {
            var accounts = await accountManager.GetAllAccounts(id);
            return View(accounts);
        }

        //Block bills as admin
        public async Task<IActionResult> BlockBill(int? id)
        {
            var bill = await billManager.GetBillPay(id);
            if (bill == null) return NotFound();

            billManager.Block(bill, !bill.Block);
            return RedirectToAction("Index", "CustomerManager");
        }

        //Unblock bills as admin
        public async Task<IActionResult> UnBlockBill(int? id)
        {
            var bills = await billManager.GetBillPay(id);
            if (bills == null) return NotFound();
            billManager.UnBlock(bills, !bills.Block);
            return RedirectToAction("Index", "CustomerManager");

        }
    }
}
