#pragma checksum "C:\Users\debora.spano\Desktop\Test.Week8\AcademyG.Week8.Esercitazione\AcademyG.Week8.Esercitazione.MVC\Views\Shared\ExceptionError.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ced2662b0f234dcdd53b4b718cbd8e56c1c95a0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ExceptionError), @"mvc.1.0.view", @"/Views/Shared/ExceptionError.cshtml")]
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
#line 1 "C:\Users\debora.spano\Desktop\Test.Week8\AcademyG.Week8.Esercitazione\AcademyG.Week8.Esercitazione.MVC\Views\_ViewImports.cshtml"
using AcademyG.Week8.Esercitazione.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\debora.spano\Desktop\Test.Week8\AcademyG.Week8.Esercitazione\AcademyG.Week8.Esercitazione.MVC\Views\_ViewImports.cshtml"
using AcademyG.Week8.Esercitazione.MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\debora.spano\Desktop\Test.Week8\AcademyG.Week8.Esercitazione\AcademyG.Week8.Esercitazione.MVC\Views\_ViewImports.cshtml"
using AcademyG.Week8.Esercitazione.Core.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ced2662b0f234dcdd53b4b718cbd8e56c1c95a0c", @"/Views/Shared/ExceptionError.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bffb0fe9566a91c4386c2d7b216f554da7b91a77", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ExceptionError : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultBL>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"alert alert-danger\" role=\"alert\">\r\n    <h1> ");
#nullable restore
#line 4 "C:\Users\debora.spano\Desktop\Test.Week8\AcademyG.Week8.Esercitazione\AcademyG.Week8.Esercitazione.MVC\Views\Shared\ExceptionError.cshtml"
    Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResultBL> Html { get; private set; }
    }
}
#pragma warning restore 1591