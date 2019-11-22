#pragma checksum "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Bonus\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c417c5e08edd45ead7e4cf0e23338b7e605186c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bonus_List), @"mvc.1.0.view", @"/Views/Bonus/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Bonus/List.cshtml", typeof(AspNetCore.Views_Bonus_List))]
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
#line 1 "C:\Users\code\source\repos\FinalProject\PayrollSystem\_ViewImports.cshtml"
using PayrollSystem;

#line default
#line hidden
#line 2 "C:\Users\code\source\repos\FinalProject\PayrollSystem\_ViewImports.cshtml"
using PayrollSystem.Models;

#line default
#line hidden
#line 3 "C:\Users\code\source\repos\FinalProject\PayrollSystem\_ViewImports.cshtml"
using PayrollSystem.ViewModels;

#line default
#line hidden
#line 1 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Bonus\List.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c417c5e08edd45ead7e4cf0e23338b7e605186c", @"/Views/Bonus/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf7f6a549143b24acabbdc1227f3f78c2fd7eb7", @"/_ViewImports.cshtml")]
    public class Views_Bonus_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WorkerVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Bonus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Bonus\List.cshtml"
  
    ViewData["Title"] = "List";

#line default
#line hidden
            BeginContext(150, 530, true);
            WriteLiteral(@"
<h2>İşçilər</h2>

<div class=""container"">
    <div style=""margin-top:10px; overflow-x:auto; overflow-y:auto;"">

        <table class=""table table-striped"">
            <thead>
                <tr>
                    <th>Ad</th>
                    <th>Soyad</th>
                    <th>Vəzifə</th>
                    <th>Departament</th>
                    <th>Başlama tarixi</th>
                    <th>Əməliyyat</th>
                </tr>
            </thead>
            <tbody id=""bonusWorkersAppend"">
");
            EndContext();
#line 25 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Bonus\List.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(745, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(800, 9, false);
#line 28 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Bonus\List.cshtml"
                       Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(809, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(845, 12, false);
#line 29 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Bonus\List.cshtml"
                       Write(item.Surname);

#line default
#line hidden
            EndContext();
            BeginContext(857, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(893, 13, false);
#line 30 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Bonus\List.cshtml"
                       Write(item.Position);

#line default
#line hidden
            EndContext();
            BeginContext(906, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(942, 15, false);
#line 31 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Bonus\List.cshtml"
                       Write(item.Department);

#line default
#line hidden
            EndContext();
            BeginContext(957, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(993, 39, false);
#line 32 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Bonus\List.cshtml"
                       Write(item.StartDate.Date.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1032, 65, true);
            WriteLiteral("</td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(1097, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "50098fb16f0b45eabdaa3ec3cc5e5aef", async() => {
                BeginContext(1173, 14, true);
                WriteLiteral("Bonus əlavə et");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 34 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Bonus\List.cshtml"
                                                                            WriteLiteral(item.WorkerId);

#line default
#line hidden
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
            EndContext();
            BeginContext(1191, 60, true);
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 37 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Bonus\List.cshtml"
                }

#line default
#line hidden
            BeginContext(1270, 134, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    <input type=\"hidden\" class=\"bonusWorkersSkipCount\" id=\"bonusWorkersTotalCount\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1404, "\"", 1430, 1);
#line 41 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Bonus\List.cshtml"
WriteAttributeValue("", 1412, ViewBag.SkipCount, 1412, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1431, 19, true);
            WriteLiteral(" />\r\n</div>\r\n\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<Worker> _userManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WorkerVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591