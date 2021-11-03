using s3713572_s3698728_a2.Data;
using s3713572_s3698728_a2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleHashing;
using System.Threading.Tasks;

namespace s3713572_s3698728_a2.Controllers
{
    [Route("Bank/SecureLogin")]
    [Area("Customer")]
    public class LoginController : Controller
    {
        private readonly BankContext _context;
        public LoginController(BankContext context) => _context = context;
        public IActionResult Login() => View();
        /// <summary>
        /// User must be logged with account in the database and the password must match with 
        /// the hased password in database
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(string loginID, string password)
        {
            var login = await _context.Login.FindAsync(loginID);
            if (login == null || !PBKDF2.Verify(login.PasswordHash, password))
            {
                ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
                return View(new Login { LoginID = loginID });
            }
            if(login.Lock == true)
            {
                ModelState.AddModelError("LoginFailed", "Your account is locked, please try again after 1 min");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.LoginID = loginID;
                return View();
            }
            // Login customer.
            HttpContext.Session.SetInt32(nameof(Customer.CustomerID), login.CustomerID);
            HttpContext.Session.SetString(nameof(Customer.CustomerName), login.Customer.CustomerName);

            return RedirectToAction("Index", "Customer");
        }

        [Route("Bank/Logout")]
        public IActionResult Logout()
        {
            // Logout customer.
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
