using System;
using s3713572_s3698728_a2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace s3713572_s3698728_a2.Filters
{
    /// <summary>
    /// This class is for authorize a logged in customer, only user with authorization can do 
    /// certain actions
    /// </summary>
    public class AuthorizeCustomer : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var customerID = context.HttpContext.Session.GetInt32(nameof(Customer.CustomerID));
            if (!customerID.HasValue)
                context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}
