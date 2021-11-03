using s3713572_s3698728_a2.Data;
using s3713572_s3698728_a2.UserCategory.Admin.Controllers.Manager;
using s3713572_s3698728_a2.UserCategory.Admin.Filter;
using s3713572_s3698728_a2.UserCategory.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace s3713572_s3698728_a2.Areas.Admin.Controllers
{
    [Area("admin")]
    [AuthorizeAdmin]
    public class TransactionManagerController : Controller
    {
        private AccountManager accountManager;
        private TransactionManager transactionManager;
        public TransactionManagerController()
        {
            accountManager = new AccountManager();
            transactionManager = new TransactionManager();
        }
        
        public async Task<IActionResult> TransactionAccountSelection(int? id)
        {
            var accounts = await accountManager.GetAllAccounts(id);
            return View(accounts);
        }
        //Get transactions
        public async Task<IActionResult> Index(int? id, DateTime startdate, DateTime enddate)
        {
            var results = await transactionManager.FilterByDateAsync(id, startdate, enddate);
            if (startdate > enddate && startdate == enddate)
            {
                ModelState.AddModelError(nameof(startdate), "start date must smaller than enddate");
                ModelState.AddModelError(nameof(enddate), "end date must greater than enddate");
            }


            if (ModelState.IsValid)
            {
                return View(results);
            }
            

            return View(results); ;
        }

        

    }
}
