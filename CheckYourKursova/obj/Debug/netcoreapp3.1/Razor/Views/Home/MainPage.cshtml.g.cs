#pragma checksum "C:\Users\1\source\repos\CheckYourKursova\CheckYourKursova\Views\Home\MainPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0635bcf98c4939c8bc4c845c0787b2e0b4b3dc8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_MainPage), @"mvc.1.0.view", @"/Views/Home/MainPage.cshtml")]
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
#line 1 "C:\Users\1\source\repos\CheckYourKursova\CheckYourKursova\Views\_ViewImports.cshtml"
using Kursova;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\1\source\repos\CheckYourKursova\CheckYourKursova\Views\_ViewImports.cshtml"
using Kursova.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0635bcf98c4939c8bc4c845c0787b2e0b4b3dc8c", @"/Views/Home/MainPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0187e2e936986cc3604ad942c816f39f7c49795b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_MainPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\1\source\repos\CheckYourKursova\CheckYourKursova\Views\Home\MainPage.cshtml"
  
    ViewData["Title"] ="Перевір свою курсову!";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 4 "C:\Users\1\source\repos\CheckYourKursova\CheckYourKursova\Views\Home\MainPage.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n<div class=\"text-center\">\r\n    <div class=\"form-group\">\r\n        <a href=\"/Account/Register\" class=\"btn btn-outline-dark\">Студент</a>\r\n        <a href=\"/Account/RegisterTeacher\" class=\"btn btn-outline-dark\">Викладач</a>\r\n    </div>\r\n</div>");
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