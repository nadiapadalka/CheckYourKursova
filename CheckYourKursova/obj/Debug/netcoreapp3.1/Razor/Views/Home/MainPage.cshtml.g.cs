#pragma checksum "D:\Documents\Nazar\University\2020\Software egineering\Project repository\CheckYourKursova\CheckYourKursova\Views\Home\MainPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d72e0a92374c9ff5128df381515c36af9d2438c"
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
#line 1 "D:\Documents\Nazar\University\2020\Software egineering\Project repository\CheckYourKursova\CheckYourKursova\Views\_ViewImports.cshtml"
using Kursova;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Documents\Nazar\University\2020\Software egineering\Project repository\CheckYourKursova\CheckYourKursova\Views\_ViewImports.cshtml"
using Kursova.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d72e0a92374c9ff5128df381515c36af9d2438c", @"/Views/Home/MainPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0187e2e936986cc3604ad942c816f39f7c49795b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_MainPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Documents\Nazar\University\2020\Software egineering\Project repository\CheckYourKursova\CheckYourKursova\Views\Home\MainPage.cshtml"
  
    ViewData["Title"] = "Для реєстрації оберіть користувача";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!--\r\n<div class=\"text-center\">\r\n</div>\r\n-->\r\n<header class=\"masthead\">\r\n    <div class=\"container\">\r\n        <div class=\"intro-text\">\r\n            <div class=\"intro-lead-in\">");
#nullable restore
#line 11 "D:\Documents\Nazar\University\2020\Software egineering\Project repository\CheckYourKursova\CheckYourKursova\Views\Home\MainPage.cshtml"
                                  Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
            <a href=""/Account/Login"" class=""btn btn-primary btn-xl text-uppercase js-scroll-trigger"">Студент</a>
            <a href=""/Account/LoginTeacher"" class=""btn btn-primary btn-xl text-uppercase js-scroll-trigger"">Викладач</a>
            <a href=""/Account/LoginAdmin"" class=""btn btn-primary btn-xl text-uppercase js-scroll-trigger"">Адміністратор</a>
        </div>
    </div>
</header>");
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
