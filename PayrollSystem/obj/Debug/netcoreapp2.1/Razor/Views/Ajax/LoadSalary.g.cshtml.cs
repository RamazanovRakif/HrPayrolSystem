#pragma checksum "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadSalary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57c2f81ea94a9d7e87b956787830309ef8957006"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ajax_LoadSalary), @"mvc.1.0.view", @"/Views/Ajax/LoadSalary.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Ajax/LoadSalary.cshtml", typeof(AspNetCore.Views_Ajax_LoadSalary))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57c2f81ea94a9d7e87b956787830309ef8957006", @"/Views/Ajax/LoadSalary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3bf7f6a549143b24acabbdc1227f3f78c2fd7eb7", @"/_ViewImports.cshtml")]
    public class Views_Ajax_LoadSalary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PayrollSystem.ViewModels.SalaryViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadSalary.cshtml"
  
    Layout = null;

#line default
#line hidden
#line 5 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadSalary.cshtml"
 for (int i = 0; i < Model.SelectedWorkers.Count; i++)
{

#line default
#line hidden
            BeginContext(135, 14, true);
            WriteLiteral("<tr>\r\n    <td>");
            EndContext();
            BeginContext(150, 29, false);
#line 8 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadSalary.cshtml"
   Write(Model.SelectedWorkers[i].Name);

#line default
#line hidden
            EndContext();
            BeginContext(179, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(195, 32, false);
#line 9 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadSalary.cshtml"
   Write(Model.SelectedWorkers[i].Surname);

#line default
#line hidden
            EndContext();
            BeginContext(227, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(243, 33, false);
#line 10 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadSalary.cshtml"
   Write(Model.SelectedWorkers[i].Position);

#line default
#line hidden
            EndContext();
            BeginContext(276, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(292, 35, false);
#line 11 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadSalary.cshtml"
   Write(Model.SelectedWorkers[i].Department);

#line default
#line hidden
            EndContext();
            BeginContext(327, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(343, 30, false);
#line 12 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadSalary.cshtml"
   Write(Model.SelectedWorkers[i].Bonus);

#line default
#line hidden
            EndContext();
            BeginContext(373, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(389, 38, false);
#line 13 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadSalary.cshtml"
   Write(Model.SelectedWorkers[i].MonthlySalary);

#line default
#line hidden
            EndContext();
            BeginContext(427, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(443, 40, false);
#line 14 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadSalary.cshtml"
   Write(Model.SelectedWorkers[i].ExcusableAbsens);

#line default
#line hidden
            EndContext();
            BeginContext(483, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(499, 42, false);
#line 15 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadSalary.cshtml"
   Write(Model.SelectedWorkers[i].UnExcusableAbsens);

#line default
#line hidden
            EndContext();
            BeginContext(541, 15, true);
            WriteLiteral("</td>\r\n    <td>");
            EndContext();
            BeginContext(557, 36, false);
#line 16 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadSalary.cshtml"
   Write(Model.SelectedWorkers[i].TotalSalary);

#line default
#line hidden
            EndContext();
            BeginContext(593, 14, true);
            WriteLiteral("</td>\r\n</tr>\r\n");
            EndContext();
#line 18 "C:\Users\code\source\repos\FinalProject\PayrollSystem\Views\Ajax\LoadSalary.cshtml"
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