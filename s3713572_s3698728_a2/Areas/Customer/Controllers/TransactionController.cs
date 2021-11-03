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
    public class TransactionController : Controller
    {
        private readonly BankContext _context;

        public TransactionController(BankContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index(int id, int pageNumber = 1)
        {

            var account = await _context.Account.FindAsync(id);
            
            return View(await PaginatedList<Transaction>.CreateAsync(_context.Transaction.Where(x => x.AccountNumber == id).OrderByDescending(x=>x.ModifyDate), pageNumber, 4));
        }

        
    }
}
