using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using s3713572_s3698728_a2.Areas.Identity.Data;
using s3713572_s3698728_a2.Data;

namespace s3713572_s3698728_a2.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string EmailRegistration { get; set; }

            [Key, Required, StringLength(8)]
            [DataType(DataType.Text)]
            public string LoginID { get; set; }

            [Required, StringLength(4)]
            [DataType(DataType.Text)]
            public int CustomerID { get; set; }

            [DataType(DataType.Password)]
            [Required, StringLength(64)]
            public string PasswordHashRegistration { get; set; }
            [Required]
            [DataType(DataType.Text)]
            public DateTime ModifyDate { get; set; }

            [Display(Name = "Customer Name")]
            [Required, StringLength(50)]
            [DataType(DataType.Text)]
            public string CustomerName { get; set; }
            [StringLength(11)]
            [DataType(DataType.Text)]
            public string TFN { get; set; }
            [StringLength(50)]
            [DataType(DataType.Text)]
            public string Address { get; set; }
            [StringLength(40)]
            [DataType(DataType.Text)]
            public string City { get; set; }
            [StringLength(20)]
            [DataType(DataType.Text)]
            [RegularExpression("VIC|NSW|QLD|TAS|WA|SA", ErrorMessage = "Wrong state format.")]
            public string State { get; set; }
            [StringLength(10)]
            [DataType(DataType.Text)]
            [MaxLength(4), MinLength(4)]
            public string PostCode { get; set; }
            [Required, StringLength(15)]
            [DataType(DataType.Text)]
            [RegularExpression(@"^[+61][0-9]{10}$",
             ErrorMessage = "Wrong phone format.")]
            public string Phone { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new CustomerRegistration { LoginID = Input.LoginID, PasswordHashRegistration = Input.PasswordHashRegistration, EmailRegistration = Input.EmailRegistration, CustomerID = Input.CustomerID, CustomerName = Input.CustomerName,
                TFN = Input.TFN, Address = Input.Address, City = Input.City, State= Input.State, PostCode = Input.PostCode, Phone = Input.Phone};
                var result = await _userManager.CreateAsync(user, Input.PasswordHashRegistration);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return RedirectToAction("Index", "Home");
        }
    }
}
