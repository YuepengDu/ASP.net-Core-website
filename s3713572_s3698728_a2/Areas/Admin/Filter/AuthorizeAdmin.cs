using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace s3713572_s3698728_a2.UserCategory.Admin.Filter
{
    /// <summary>
    /// This class give authorization to admin after login to do certain actions
    /// </summary>
    public class AuthorizeAdmin: Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var Admin = context.HttpContext.Session.GetString("Admin");
            if (Admin == null)
            {
                context.Result = new RedirectToActionResult("Error", "Admin", null);
            }
        }
    }
}
