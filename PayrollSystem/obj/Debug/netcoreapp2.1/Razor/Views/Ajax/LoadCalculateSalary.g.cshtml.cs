#pragma checksum "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6c244c6b631a35d8f8076faa6711d77cfe17ed3c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ajax_LoadCalculateSalary), @"mvc.1.0.view", @"/Views/Ajax/LoadCalculateSalary.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Ajax/LoadCalculateSalary.cshtml", typeof(AspNetCore.Views_Ajax_LoadCalculateSalary))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6c244c6b631a35d8f8076faa6711d77cfe17ed3c", @"/Views/Ajax/LoadCalculateSalary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf7f6a549143b24acabbdc1227f3f78c2fd7eb7", @"/_ViewImports.cshtml")]
    public class Views_Ajax_LoadCalculateSalary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PayrollSystem.ViewModels.SalaryViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
 for (int i = 0; i < Model.SelectedWorkers.Count; i++)
{

#line default
#line hidden
            BeginContext(108, 33, true);
            WriteLiteral("<tr>\r\n    <td style=\"padding:0;\">");
            EndContext();
            BeginContext(142, 56, false);
#line 5 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
                      Write(Html.HiddenFor(x => Model.SelectedWorkers[i].EmployeeId));

#line default
#line hidden
            EndContext();
            BeginContext(198, 34, true);
            WriteLiteral("</td>\r\n    <td style=\"padding:0;\">");
            EndContext();
            BeginContext(233, 58, false);
#line 6 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
                      Write(Html.HiddenFor(x => Model.SelectedWorkers[i].IDCardNumber));

#line default
#line hidden
            EndContext();
            BeginContext(291, 34, true);
            WriteLiteral("</td>\r\n    <td style=\"padding:0;\">");
            EndContext();
            BeginContext(326, 57, false);
#line 7 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
                      Write(Html.HiddenFor(x => Model.SelectedWorkers[i].TotalSalary));

#line default
#line hidden
            EndContext();
            BeginContext(383, 34, true);
            WriteLiteral("</td>\r\n    <td style=\"padding:0;\">");
            EndContext();
            BeginContext(418, 58, false);
#line 8 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
                      Write(Html.HiddenFor(x => Model.SelectedWorkers[i].OldCalculate));

#line default
#line hidden
            EndContext();
            BeginContext(476, 34, true);
            WriteLiteral("</td>\r\n    <td style=\"padding:0;\">");
            EndContext();
            BeginContext(511, 50, false);
#line 9 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
                      Write(Html.HiddenFor(x => Model.SelectedWorkers[i].Name));

#line default
#line hidden
            EndContext();
            BeginContext(561, 34, true);
            WriteLiteral("</td>\r\n    <td style=\"padding:0;\">");
            EndContext();
            BeginContext(596, 53, false);
#line 10 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
                      Write(Html.HiddenFor(x => Model.SelectedWorkers[i].Surname));

#line default
#line hidden
            EndContext();
            BeginContext(649, 34, true);
            WriteLiteral("</td>\r\n    <td style=\"padding:0;\">");
            EndContext();
            BeginContext(684, 54, false);
#line 11 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
                      Write(Html.HiddenFor(x => Model.SelectedWorkers[i].Position));

#line default
#line hidden
            EndContext();
            BeginContext(738, 25, true);
            WriteLiteral("</td>\r\n    <td>\r\n        ");
            EndContext();
            BeginContext(764, 58, false);
#line 13 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
   Write(Html.CheckBoxFor(it => Model.SelectedWorkers[i].IsChecked));

#line default
#line hidden
            EndContext();
            BeginContext(822, 21, true);
            WriteLiteral("\r\n    </td>\r\n    <td>");
            EndContext();
            BeginContext(844, 29, false);
#line 15 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
   Write(Model.SelectedWorkers[i].Name);

#line default
#line hidden
            EndContext();
            BeginContext(873, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(889, 32, false);
#line 16 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
   Write(Model.SelectedWorkers[i].Surname);

#line default
#line hidden
            EndContext();
            BeginContext(921, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(937, 33, false);
#line 17 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
   Write(Model.SelectedWorkers[i].Position);

#line default
#line hidden
            EndContext();
            BeginContext(970, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(986, 35, false);
#line 18 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
   Write(Model.SelectedWorkers[i].Department);

#line default
#line hidden
            EndContext();
            BeginContext(1021, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(1037, 30, false);
#line 19 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
   Write(Model.SelectedWorkers[i].Bonus);

#line default
#line hidden
            EndContext();
            BeginContext(1067, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(1083, 38, false);
#line 20 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
   Write(Model.SelectedWorkers[i].MonthlySalary);

#line default
#line hidden
            EndContext();
            BeginContext(1121, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(1137, 62, false);
#line 21 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
   Write(Model.SelectedWorkers[i].OldCalculate.Date.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1199, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(1215, 40, false);
#line 22 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
   Write(Model.SelectedWorkers[i].ExcusableAbsens);

#line default
#line hidden
            EndContext();
            BeginContext(1255, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(1271, 42, false);
#line 23 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
   Write(Model.SelectedWorkers[i].UnExcusableAbsens);

#line default
#line hidden
            EndContext();
            BeginContext(1313, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(1329, 36, false);
#line 24 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
   Write(Model.SelectedWorkers[i].TotalSalary);

#line default
#line hidden
            EndContext();
            BeginContext(1365, 14, true);
            WriteLiteral("</td>\r\n</tr>\r\n");
            EndContext();
#line 26 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadCalculateSalary.cshtml"
}

#line default
#line hidden
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
