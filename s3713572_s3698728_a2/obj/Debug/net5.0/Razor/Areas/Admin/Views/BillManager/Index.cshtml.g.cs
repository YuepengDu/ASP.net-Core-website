#pragma checksum "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80e526e2b872dfbcb739eb36a4d2543af81ca23d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_BillManager_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/BillManager/Index.cshtml")]
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
#line 1 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\_ViewImports.cshtml"
using s3713572_s3698728_a2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\_ViewImports.cshtml"
using s3713572_s3698728_a2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80e526e2b872dfbcb739eb36a4d2543af81ca23d", @"/Areas/Admin/Views/BillManager/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"124123f9042ce3a996aada369f6da7a90ccb170a", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_BillManager_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<s3713572_s3698728_a2.UserCategory.Admin.Models.BillPay>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "BillManager", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UnBlockBill", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "BlockBill", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("overall-background"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
   ViewData["Title"] = "Account List"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80e526e2b872dfbcb739eb36a4d2543af81ca23d5227", async() => {
                WriteLiteral(@"
    <div class=""content-middle-page"">
        <div class=""content-size"">
            <h1>Select an account to manage its bill payment</h1>

            <table class=""table"">
                <thead>
                    <tr>
                        <th>
                            ");
#nullable restore
#line 25 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.BillPayId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 28 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.AccountNumber));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 31 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.PayeeID));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 34 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 37 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.ScheduleDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 40 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.Period));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 43 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.ModifyDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 46 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.Block));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th></th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 52 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 56 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.BillPayId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 59 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.AccountNumber));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 62 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.PayeeID));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 65 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 68 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ScheduleDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 71 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Period));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 74 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ModifyDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 77 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Block));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n");
#nullable restore
#line 79 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                             if (isBlocked(item.Block))
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <td>\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80e526e2b872dfbcb739eb36a4d2543af81ca23d12368", async() => {
                    WriteLiteral("UnBlock");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 82 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                                                                                                                            WriteLiteral(item.BillPayId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                </td>\r\n");
#nullable restore
#line 84 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"

                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <td>\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "80e526e2b872dfbcb739eb36a4d2543af81ca23d15399", async() => {
                    WriteLiteral("Block");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 89 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                                                                                                                          WriteLiteral(item.BillPayId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                </td>\r\n");
#nullable restore
#line 91 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 95 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
#nullable restore
#line 5 "D:\A2\s3713572_s3698728_a2\Areas\Admin\Views\BillManager\Index.cshtml"
           
    public bool isBlocked(bool status)
    {
        if (status == true)
        {
            return true;
        }
        return false;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<s3713572_s3698728_a2.UserCategory.Admin.Models.BillPay>> Html { get; private set; }
    }
}
#pragma warning restore 1591