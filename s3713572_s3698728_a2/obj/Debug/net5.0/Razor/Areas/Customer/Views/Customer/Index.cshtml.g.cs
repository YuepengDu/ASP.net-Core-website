#pragma checksum "D:\A2\s3713572_s3698728_a2\Areas\Customer\Views\Customer\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a71f4eadf3578261fae52ce9e052cfb1a98cd5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Customer_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/Customer/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\A2\s3713572_s3698728_a2\Areas\Customer\Views\_ViewImports.cshtml"
using s3713572_s3698728_a2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\A2\s3713572_s3698728_a2\Areas\Customer\Views\_ViewImports.cshtml"
using s3713572_s3698728_a2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a71f4eadf3578261fae52ce9e052cfb1a98cd5b", @"/Areas/Customer/Views/Customer/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"124123f9042ce3a996aada369f6da7a90ccb170a", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    public class Areas_Customer_Views_Customer_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Customer>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("overall-background"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\A2\s3713572_s3698728_a2\Areas\Customer\Views\Customer\Index.cshtml"
  
    ViewData["Title"] = "Accounts";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a71f4eadf3578261fae52ce9e052cfb1a98cd5b3660", async() => {
                WriteLiteral("\r\n<div class=\"content-middle-page\">\r\n    <div class=\"content-size\">\r\n    <h1 class=\"display-4 text-position-fix\">Welcome, ");
#nullable restore
#line 8 "D:\A2\s3713572_s3698728_a2\Areas\Customer\Views\Customer\Index.cshtml"
                                                Write(Model.CustomerName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n    \r\n     \r\n    <table class=\"table\">\r\n        <tr>\r\n            <th>");
#nullable restore
#line 13 "D:\A2\s3713572_s3698728_a2\Areas\Customer\Views\Customer\Index.cshtml"
           Write(Html.DisplayNameFor(x => x.Accounts[0].AccountNumber));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 14 "D:\A2\s3713572_s3698728_a2\Areas\Customer\Views\Customer\Index.cshtml"
           Write(Html.DisplayNameFor(x => x.Accounts[0].AccountType));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n            <th>");
#nullable restore
#line 15 "D:\A2\s3713572_s3698728_a2\Areas\Customer\Views\Customer\Index.cshtml"
           Write(Html.DisplayNameFor(x => x.Accounts[0].Balance));

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n            <th></th>\r\n        </tr>\r\n");
#nullable restore
#line 18 "D:\A2\s3713572_s3698728_a2\Areas\Customer\Views\Customer\Index.cshtml"
         foreach(var account in Model.Accounts) {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 20 "D:\A2\s3713572_s3698728_a2\Areas\Customer\Views\Customer\Index.cshtml"
               Write(Html.DisplayFor(x => account.AccountNumber));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 21 "D:\A2\s3713572_s3698728_a2\Areas\Customer\Views\Customer\Index.cshtml"
               Write(Html.DisplayFor(x => account.AccountType));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "D:\A2\s3713572_s3698728_a2\Areas\Customer\Views\Customer\Index.cshtml"
               Write(Html.DisplayFor(x => account.Balance));

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 24 "D:\A2\s3713572_s3698728_a2\Areas\Customer\Views\Customer\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </table>\r\n    </div>\r\n</div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Customer> Html { get; private set; }
    }
}
#pragma warning restore 1591
