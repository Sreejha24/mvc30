#pragma checksum "\\192.168.50.220\Freshers2020-Trainees\NewCore3xMVC\NewCore3xMVC\Views\Default\_DefaultPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "922b74923ec4885e735fb7bf8e1cef2eb2e25944"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Default__DefaultPartial), @"mvc.1.0.view", @"/Views/Default/_DefaultPartial.cshtml")]
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
#line 1 "\\192.168.50.220\Freshers2020-Trainees\NewCore3xMVC\NewCore3xMVC\Views\_ViewImports.cshtml"
using NewCore3xMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "\\192.168.50.220\Freshers2020-Trainees\NewCore3xMVC\NewCore3xMVC\Views\_ViewImports.cshtml"
using NewCore3xMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"922b74923ec4885e735fb7bf8e1cef2eb2e25944", @"/Views/Default/_DefaultPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8747b246c1f423209418191b43543c9079de7af4", @"/Views/_ViewImports.cshtml")]
    public class Views_Default__DefaultPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"card card-body bg-info\">\r\n    <p>\r\n        Partial View from <b>Default folder</b>: Today is ");
#nullable restore
#line 3 "\\192.168.50.220\Freshers2020-Trainees\NewCore3xMVC\NewCore3xMVC\Views\Default\_DefaultPartial.cshtml"
                                                     Write(DateTime.Now.ToLongDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
