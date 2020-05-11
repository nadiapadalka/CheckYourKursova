#pragma checksum "C:\Users\LNU9\Source\Repos3\nadiapadalka\CheckYourKursova\CheckYourKursova\Views\Admin\StudentDocuments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fad174cd0f7c6d84b7bd075d4fd775240cbf77cd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_StudentDocuments), @"mvc.1.0.view", @"/Views/Admin/StudentDocuments.cshtml")]
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
#line 1 "C:\Users\LNU9\Source\Repos3\nadiapadalka\CheckYourKursova\CheckYourKursova\Views\_ViewImports.cshtml"
using Kursova;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LNU9\Source\Repos3\nadiapadalka\CheckYourKursova\CheckYourKursova\Views\_ViewImports.cshtml"
using Kursova.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fad174cd0f7c6d84b7bd075d4fd775240cbf77cd", @"/Views/Admin/StudentDocuments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0187e2e936986cc3604ad942c816f39f7c49795b", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_StudentDocuments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Kursova.DAL.Entities.Documentation>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteStudentDocument", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\LNU9\Source\Repos3\nadiapadalka\CheckYourKursova\CheckYourKursova\Views\Admin\StudentDocuments.cshtml"
  
    ViewData["Title"] = "StudentsDocuments";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<header class=""masthead"">
    <div class=""container"">
        <div class=""intro-text"">
            <div class=""card card-2"">
                <div class=""card-body"">
                    <h1>Students Documents</h1>

                    <div class=""text-center"">
                        <br />
                        <h2 style=""color:black"">Всі документи</h2>
                        <table style=""width:100%"">
                            <tr>
                                <th>Назва</th>
                                <th>Опис</th>
                                <th>Прикріплені матеріали</th>
                                <th></th>
                            </tr>
");
#nullable restore
#line 24 "C:\Users\LNU9\Source\Repos3\nadiapadalka\CheckYourKursova\CheckYourKursova\Views\Admin\StudentDocuments.cshtml"
                              
                                foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 28 "C:\Users\LNU9\Source\Repos3\nadiapadalka\CheckYourKursova\CheckYourKursova\Views\Admin\StudentDocuments.cshtml"
                                       Write(item.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 29 "C:\Users\LNU9\Source\Repos3\nadiapadalka\CheckYourKursova\CheckYourKursova\Views\Admin\StudentDocuments.cshtml"
                                       Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n");
#nullable restore
#line 31 "C:\Users\LNU9\Source\Repos3\nadiapadalka\CheckYourKursova\CheckYourKursova\Views\Admin\StudentDocuments.cshtml"
                                               
                                                foreach (var doc in item.AttachedStudentMaterials.Split("/"))
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <p>doc</p>\r\n");
#nullable restore
#line 35 "C:\Users\LNU9\Source\Repos3\nadiapadalka\CheckYourKursova\CheckYourKursova\Views\Admin\StudentDocuments.cshtml"
                                                }
                                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\r\n                                        <td>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fad174cd0f7c6d84b7bd075d4fd775240cbf77cd7019", async() => {
                WriteLiteral("\r\n                                                <input type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 1796, "\"", 1812, 1);
#nullable restore
#line 40 "C:\Users\LNU9\Source\Repos3\nadiapadalka\CheckYourKursova\CheckYourKursova\Views\Admin\StudentDocuments.cshtml"
WriteAttributeValue("", 1804, item.Id, 1804, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" name=""id"" />
                                                <button type=""submit"" class=""btn btn-outline-dark"">
                                                    Видалити
                                                </button>
                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 47 "C:\Users\LNU9\Source\Repos3\nadiapadalka\CheckYourKursova\CheckYourKursova\Views\Admin\StudentDocuments.cshtml"
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </table>\r\n                        <br />\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</header>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Kursova.DAL.Entities.Documentation>> Html { get; private set; }
    }
}
#pragma warning restore 1591
