using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using s3713572_s3698728_a2.Data;
using s3713572_s3698728_a2.Models;

namespace s3713572_s3698728_a2.Controllers
{
    [Area("Customer")]
    public class AccountController : Controller
    {
        private readonly BankContext _context;

        public AccountController(BankContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            var bankContext = _context.Account.Include(a => a.Customer);
            return View(await bankContext.ToListAsync());
        }

        
    }
}
