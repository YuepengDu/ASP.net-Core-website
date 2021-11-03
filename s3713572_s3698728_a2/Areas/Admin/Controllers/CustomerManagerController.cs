using s3713572_s3698728_a2.UserCategory.Admin.Controllers.Manager;
using s3713572_s3698728_a2.UserCategory.Admin.Filter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace s3713572_s3698728_a2.Areas.Admin.Controllers
{
    [Area("admin")]
    [AuthorizeAdmin]
    public class CustomerManagerController : Controller
    {
        private CustomerManager customerManager;
        private LoginManager loginManager;
        private AccountManager accountManager;
        public CustomerManagerController()
        {
            customerManager = new CustomerManager();
            loginManager = new LoginManager();
            accountManager = new AccountManager();
        }
        /// <summary>
        /// Get: Get All Customers 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var customers = await customerManager.GetAllCustomers();
            return View(customers);
        }
        //Lock customer account as admin
        public async Task<IActionResult> Lock(int? id)
        {
            if (id == null) return NotFound();
            var login = await loginManager.GetLogin(id);
            if(login == null)
            {
                return NotFound();
            }
            return View(login);
        }
        [HttpPost]
        public async Task<IActionResult> Lock(int CustomerID)
        {
            var login = await loginManager.GetLogin(CustomerID);
            if (login == null) return NotFound();

            loginManager.Lock(login, !login.Lock);

            return View(login);

        }
        //Get all accounts
        [HttpPost]
        public async Task<IActionResult> GetAccount(int? id)
        {
            var accounts = await accountManager.GetAccount(id);
            return View(accounts);
        }

    }
}
