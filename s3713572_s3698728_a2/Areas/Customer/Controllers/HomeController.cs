using s3713572_s3698728_a2.Data;
using s3713572_s3698728_a2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace s3713572_s3698728_a2.Controllers
{
    /// <summary>
    /// This class returns the basic Home page
    /// </summary>
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly BankContext _context;
        private int CustomerID => HttpContext.Session.GetInt32(nameof(Customer.CustomerID)).Value;

        public HomeController(BankContext context) => _context = context;

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });


    }
}
