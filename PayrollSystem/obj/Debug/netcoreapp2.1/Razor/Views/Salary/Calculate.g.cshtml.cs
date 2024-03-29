#pragma checksum "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5285ba1404b82957375774354e42c5f2bd3ed3c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Salary_Calculate), @"mvc.1.0.view", @"/Views/Salary/Calculate.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Salary/Calculate.cshtml", typeof(AspNetCore.Views_Salary_Calculate))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5285ba1404b82957375774354e42c5f2bd3ed3c3", @"/Views/Salary/Calculate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf7f6a549143b24acabbdc1227f3f78c2fd7eb7", @"/_ViewImports.cshtml")]
    public class Views_Salary_Calculate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PayrollSystem.ViewModels.SalaryViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Calculate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Salary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
  
    ViewData["Title"] = "Calculate";

#line default
#line hidden
            BeginContext(94, 103, true);
            WriteLiteral("<div class=\"col-md-12\">\r\n    <div style=\"margin-top:10px; overflow-x:auto; overflow-y:auto;\">\r\n        ");
            EndContext();
            BeginContext(197, 3005, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "67ff4172757243bd81f828efaba9b3ce", async() => {
                BeginContext(250, 1013, true);
                WriteLiteral(@"
            <table class=""table table-striped"">
                <thead>
                    <tr>
                        <th style=""padding:0;""></th>
                        <th style=""padding:0;""></th>
                        <th style=""padding:0;""></th>
                        <th style=""padding:0;""></th>
                        <th style=""padding:0;""></th>
                        <th style=""padding:0;""></th>
                        <th style=""padding:0;""></th>
                        <th>Seç</th>
                        <th>Ad</th>
                        <th>Soyad</th>
                        <th>Vəzifə</th>
                        <th>Departament</th>
                        <th>Bonus</th>
                        <th>Aylıq məvacib</th>
                        <th>Üzürlü qayıblar</th>
                        <th>Üzürsüz qayıblar</th>
                        <th>Ümumi maaş</th>
                    </tr>
                </thead>
                <tbody id=""calcSalAppend"">
");
                EndContext();
#line 31 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                     for (int i = 0; i < Model.SelectedWorkers.Count; i++)
                    {

#line default
#line hidden
                BeginContext(1362, 73, true);
                WriteLiteral("                    <tr>\r\n                        <td style=\"padding:0;\">");
                EndContext();
                BeginContext(1436, 56, false);
#line 34 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                                          Write(Html.HiddenFor(x => Model.SelectedWorkers[i].EmployeeId));

#line default
#line hidden
                EndContext();
                BeginContext(1492, 54, true);
                WriteLiteral("</td>\r\n                        <td style=\"padding:0;\">");
                EndContext();
                BeginContext(1547, 58, false);
#line 35 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                                          Write(Html.HiddenFor(x => Model.SelectedWorkers[i].IDCardNumber));

#line default
#line hidden
                EndContext();
                BeginContext(1605, 54, true);
                WriteLiteral("</td>\r\n                        <td style=\"padding:0;\">");
                EndContext();
                BeginContext(1660, 57, false);
#line 36 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                                          Write(Html.HiddenFor(x => Model.SelectedWorkers[i].TotalSalary));

#line default
#line hidden
                EndContext();
                BeginContext(1717, 54, true);
                WriteLiteral("</td>\r\n                        <td style=\"padding:0;\">");
                EndContext();
                BeginContext(1772, 58, false);
#line 37 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                                          Write(Html.HiddenFor(x => Model.SelectedWorkers[i].OldCalculate));

#line default
#line hidden
                EndContext();
                BeginContext(1830, 54, true);
                WriteLiteral("</td>\r\n                        <td style=\"padding:0;\">");
                EndContext();
                BeginContext(1885, 50, false);
#line 38 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                                          Write(Html.HiddenFor(x => Model.SelectedWorkers[i].Name));

#line default
#line hidden
                EndContext();
                BeginContext(1935, 54, true);
                WriteLiteral("</td>\r\n                        <td style=\"padding:0;\">");
                EndContext();
                BeginContext(1990, 53, false);
#line 39 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                                          Write(Html.HiddenFor(x => Model.SelectedWorkers[i].Surname));

#line default
#line hidden
                EndContext();
                BeginContext(2043, 54, true);
                WriteLiteral("</td>\r\n                        <td style=\"padding:0;\">");
                EndContext();
                BeginContext(2098, 54, false);
#line 40 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                                          Write(Html.HiddenFor(x => Model.SelectedWorkers[i].Position));

#line default
#line hidden
                EndContext();
                BeginContext(2152, 65, true);
                WriteLiteral("</td>\r\n                        <td>\r\n                            ");
                EndContext();
                BeginContext(2218, 58, false);
#line 42 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                       Write(Html.CheckBoxFor(it => Model.SelectedWorkers[i].IsChecked));

#line default
#line hidden
                EndContext();
                BeginContext(2276, 61, true);
                WriteLiteral("\r\n                        </td>\r\n                        <td>");
                EndContext();
                BeginContext(2338, 29, false);
#line 44 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                       Write(Model.SelectedWorkers[i].Name);

#line default
#line hidden
                EndContext();
                BeginContext(2367, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(2403, 32, false);
#line 45 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                       Write(Model.SelectedWorkers[i].Surname);

#line default
#line hidden
                EndContext();
                BeginContext(2435, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(2471, 33, false);
#line 46 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                       Write(Model.SelectedWorkers[i].Position);

#line default
#line hidden
                EndContext();
                BeginContext(2504, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(2540, 35, false);
#line 47 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                       Write(Model.SelectedWorkers[i].Department);

#line default
#line hidden
                EndContext();
                BeginContext(2575, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(2611, 30, false);
#line 48 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                       Write(Model.SelectedWorkers[i].Bonus);

#line default
#line hidden
                EndContext();
                BeginContext(2641, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(2677, 38, false);
#line 49 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                       Write(Model.SelectedWorkers[i].MonthlySalary);

#line default
#line hidden
                EndContext();
                BeginContext(2715, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(2751, 40, false);
#line 50 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                       Write(Model.SelectedWorkers[i].ExcusableAbsens);

#line default
#line hidden
                EndContext();
                BeginContext(2791, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(2827, 42, false);
#line 51 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                       Write(Model.SelectedWorkers[i].UnExcusableAbsens);

#line default
#line hidden
                EndContext();
                BeginContext(2869, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(2905, 36, false);
#line 52 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                       Write(Model.SelectedWorkers[i].TotalSalary);

#line default
#line hidden
                EndContext();
                BeginContext(2941, 34, true);
                WriteLiteral("</td>\r\n                    </tr>\r\n");
                EndContext();
#line 54 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Salary\Calculate.cshtml"
                    }

#line default
#line hidden
                BeginContext(2998, 197, true);
                WriteLiteral("                </tbody>\r\n            </table>\r\n            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Calculate\" class=\"btn btn-success\" />\r\n            </div>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3202, 22, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PayrollSystem.ViewModels.SalaryViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
