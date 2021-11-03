using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace s3713572_s3698728_a2.UserCategory.Admin.Controllers
{
    [Area("admin")]
    public class AdminController : Controller
    {
        [Route("Bank/SecureAdminLogin")]
        public IActionResult AdminLogin()
        {
            if (HttpContext.Session.GetString("Admin") != null)
            {
                return RedirectToAction("Index", "CustomersManager");
            }
            else
            {
                return View();
            }
        }
        /// <summary>
        /// Admin login method
        /// </summary>
        /// <param name="LoginID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Route("Bank/SecureAdminLogin")]
        [HttpPost]
        public IActionResult AdminLogin(string LoginID, string password)
        {
            if (!(LoginID == "admin" && password == "admin"))
            {
                ModelState.AddModelError("LoginFailed", "Username or password is incorrect, please try again.");
            }
            if (!ModelState.IsValid)
            {
                ViewBag.LoginID = LoginID;
                return View();
            }

            HttpContext.Session.SetString("Admin", LoginID);
            return RedirectToAction("Index", "CustomerManager");
        }
        [Route("Bank/AdminLogout")]
        public IActionResult AdminLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("AdminLogin", "Admin");
        }
        //Go to Error page if not log in
/*        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }*/
    }
}
