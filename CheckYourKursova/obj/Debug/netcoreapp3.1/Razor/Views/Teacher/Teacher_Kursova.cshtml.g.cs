#pragma checksum "C:\Users\1\source\repos\CheckYourKursova\CheckYourKursova\Views\Teacher\Teacher_Kursova.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f13be649c809329ca05ea7e6c7d066bf714175cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_Teacher_Kursova), @"mvc.1.0.view", @"/Views/Teacher/Teacher_Kursova.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f13be649c809329ca05ea7e6c7d066bf714175cf", @"/Views/Teacher/Teacher_Kursova.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0187e2e936986cc3604ad942c816f39f7c49795b", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_Teacher_Kursova : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Kursova.ViewModels.CourseProjects>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetFile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Teacher", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UploadFile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("page-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- model IEnumerable<Kursova.DAL.Entities.Teacher> -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f13be649c809329ca05ea7e6c7d066bf714175cf6203", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\">\r\n    <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 256, "\"", 266, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n    <meta name=\"author\"");
                BeginWriteAttribute("content", " content=\"", 293, "\"", 303, 0);
                EndWriteAttribute();
                WriteLiteral(@">

    <link rel=""icon"" href=""img/logos/logo.png"" sizes=""32x32"">

    <title>Kursova</title>

    <!-- Bootstrap core CSS -->
    <link href=""vendor/bootstrap/css/bootstrap.min.css"" rel=""stylesheet"">

    <!-- Custom fonts for this template -->
    <link href=""vendor/fontawesome-free/css/all.min.css"" rel=""stylesheet"" type=""text/css"">
    <link href=""https://fonts.googleapis.com/css?family=Montserrat:400,700"" rel=""stylesheet"" type=""text/css"">
    <link href='https://fonts.googleapis.com/css?family=Kaushan+Script' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700' rel='stylesheet' type='text/css'>

    <!-- Custom styles for this template -->
    <link href=""css/agency.min.css"" rel=""stylesheet"">

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f13be649c809329ca05ea7e6c7d066bf714175cf8620", async() => {
                WriteLiteral(@"

    <!-- Navigation -->
    <nav class=""navbar navbar-expand-lg navbar-dark fixed-top"" id=""mainNav"">
        <div class=""container"">
            <a class=""navbar-brand"" href=""index.html"">
            </a>

            <div class=""collapse navbar-collapse"" id=""navbarResponsive"">
                <ul class=""navbar-nav text-uppercase ml-auto"">
                    <li class=""nav-item"">
                        <a class=""nav-link js-scroll-trigger"" href=""student_home.html"">Моя сторінка</a>
                    </li>
                    <li class=""nav-item"">
                        <a class=""nav-link js-scroll-trigger"" href=""student_kursova.html"">Список курсових</a>
                    </li>
                    <li class=""nav-item"">
                        <button type=""button"" class=""btn btn-primary"" href=""student_notification.html"">
                            Сповіщення &nbsp;
                            <span class=""badge badge-light"">5</span>
                            <span class=""sr-only""");
                WriteLiteral(@">непрочитані сповіщення</span>
                        </button>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <header class=""masthead"">
        <div class=""container"">
            <div class=""intro-text"">
                <div class=""card card-2"">

                    <section class=""bg-light page-section"" id=""kursovalist"">

                        <div class=""row"">
                            &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;
                            <div class=""form-group"">
                                <div class=""dropdown open"">
                                    <a class=""btn btn-secondary dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">Прізвище та ініціали студента</a>
                                    <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuLink"">
");
#nullable restore
#line 68 "C:\Users\1\source\repos\CheckYourKursova\CheckYourKursova\Views\Teacher\Teacher_Kursova.cshtml"
                                          
                                            foreach (var item in Model.AllProjects)
                                            {
                                                

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <a class=\"dropdown-item\">");
#nullable restore
#line 75 "C:\Users\1\source\repos\CheckYourKursova\CheckYourKursova\Views\Teacher\Teacher_Kursova.cshtml"
                                                                    Write(item.StudentName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n");
#nullable restore
#line 76 "C:\Users\1\source\repos\CheckYourKursova\CheckYourKursova\Views\Teacher\Teacher_Kursova.cshtml"
                                            }
                                        

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    </div>
                                </div><br>
                                <input type=""thema"" class=""form-control"" id=""ThemaKursova"" placeholder=""Тема курсової""><br><br>

                                <span style=""font-weight: bold;"" class=""text-dark"">Матеріали студента</span>

");
#nullable restore
#line 84 "C:\Users\1\source\repos\CheckYourKursova\CheckYourKursova\Views\Teacher\Teacher_Kursova.cshtml"
                                  
                                    foreach (var item in Model.CurrentProject.StudentMaterials)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                        <div class=""input-group mb-3"">
                                            <label for=""inputDocument"" class=""sr-only"">Документ</label>
                                            <input type=""text"" readonly class=""form-control"" id=""staticDocument""");
                BeginWriteAttribute("placeholder", " placeholder=\"", 4778, "\"", 4797, 1);
#nullable restore
#line 89 "C:\Users\1\source\repos\CheckYourKursova\CheckYourKursova\Views\Teacher\Teacher_Kursova.cshtml"
WriteAttributeValue("", 4792, item, 4792, 5, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                            <div class=\"input-group-append\">\r\n                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f13be649c809329ca05ea7e6c7d066bf714175cf13596", async() => {
                    WriteLiteral("\r\n                                                    <input type=\"hidden\"");
                    BeginWriteAttribute("value", " value=\"", 5041, "\"", 5054, 1);
#nullable restore
#line 92 "C:\Users\1\source\repos\CheckYourKursova\CheckYourKursova\Views\Teacher\Teacher_Kursova.cshtml"
WriteAttributeValue("", 5049, item, 5049, 5, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" name=\"filename\" />\r\n                                                    <button type=\"submit\" class=\"btn btn-outline-secondary\">Download!</button>\r\n                                                ");
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
                WriteLiteral(@"
                                            </div>
                                        </div>
                                        <div class=""input-group mb-3"">
                                            <label for=""inputText"" class=""sr-only"">Додати коментар</label>
                                            <input type=""text"" class=""form-control"" id=""inputText"" placeholder=""Додати коментар"">
                                            <div class=""input-group-append"">
                                                <button type=""submit"" class=""btn btn-primary"">+</button>
                                            </div>
                                        </div>
");
#nullable restore
#line 104 "C:\Users\1\source\repos\CheckYourKursova\CheckYourKursova\Views\Teacher\Teacher_Kursova.cshtml"
                                    }
                                

#line default
#line hidden
#nullable disable
                WriteLiteral(@"


                            </div>
                            &emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;
                            &emsp;&emsp;

                            <div class=""form-group"">
                                <div class=""mx-sm-3 mb-2"">
                                    <span style=""font-weight: bold;"" class=""text-dark"">Завдання виконані студентом</span>
                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f13be649c809329ca05ea7e6c7d066bf714175cf17478", async() => {
                    WriteLiteral(@"
                                        <div class=""input-group mb-3"">
                                            <label for=""inputTask"" class=""sr-only"">Завдання</label>
                                            <input type=""text"" readonly class=""form-control"" id=""staticTask"" placeholder=""Завдання"">
                                            <button type=""checkbox"" class=""btn btn-primary"">✓</button>
                                        </div>
                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f13be649c809329ca05ea7e6c7d066bf714175cf19413", async() => {
                    WriteLiteral(@"
                                        <div class=""input-group mb-3"">
                                            <label for=""inputTask"" class=""sr-only"">Завдання</label>
                                            <input type=""text"" readonly class=""form-control"" id=""staticTask"" placeholder=""Завдання"">
                                            <button type=""checkbox"" class=""btn btn-primary"">✓</button>
                                        </div>
                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f13be649c809329ca05ea7e6c7d066bf714175cf21348", async() => {
                    WriteLiteral(@"
                                        <div class=""input-group mb-3"">
                                            <label for=""inputTask"" class=""sr-only"">Завдання</label>
                                            <input type=""text"" readonly class=""form-control"" id=""staticTask"" placeholder=""Завдання"">
                                            <button type=""button"" class=""btn btn-primary"">✓</button>
                                        </div>
                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f13be649c809329ca05ea7e6c7d066bf714175cf23281", async() => {
                    WriteLiteral(@"
                                        <div class=""input-group mb-3"">
                                            <label for=""inputTask"" class=""sr-only"">Завдання</label>
                                            <input type=""text"" readonly class=""form-control"" id=""staticTask"" placeholder=""Завдання"">
                                            <button type=""button"" class=""btn btn-primary"">✓</button>
                                        </div>
                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    <br><br>


                                    <span style=""font-weight: bold;"" class=""text-dark"">
                                        Додати матеріали
                                        <br><br>
                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f13be649c809329ca05ea7e6c7d066bf714175cf25464", async() => {
                    WriteLiteral("\r\n                                            <input type=\"file\" name=\"file\" />\r\n                                            <button type=\"submit\">Submit</button>\r\n                                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                        <!--<br><br><input type=""file"" class=""form-control-file"" id=""exampleInputFile"" aria-describedby=""fileHelp""> -->
                                    </span>


                                    <br><br>

                                    <label for=""inputDocument"" class=""sr-only"">Документ</label>
                                    <input type=""text"" readonly class=""form-control"" id=""staticDocument"" placeholder=""Документ"">
                                    <label for=""inputDocument"" class=""sr-only"">Документ</label>
                                    <input type=""text"" readonly class=""form-control"" id=""staticDocument"" placeholder=""Документ"">
                                    <label for=""inputDocument"" class=""sr-only"">Документ</label>
                                    <input type=""text"" readonly class=""form-control"" id=""staticDocument"" placeholder=""Документ"">
                                    <label for=""inputDocument"" class=""sr-only"">Документ</la");
                WriteLiteral(@"bel>
                                    <input type=""text"" readonly class=""form-control"" id=""staticDocument"" placeholder=""Документ"">
                                    <label for=""inputDocument"" class=""sr-only"">Документ</label>
                                    <input type=""text"" readonly class=""form-control"" id=""staticDocument"" placeholder=""Документ"">

                                </div>
                            </div>
                        </div>

                    </section>


                </div>
            </div>
        </div>
    </header>

    <!-- Bootstrap core JavaScript -->
    <script src=""vendor/jquery/jquery.min.js""></script>
    <script src=""vendor/bootstrap/js/bootstrap.bundle.min.js""></script>

    <!-- Plugin JavaScript -->
    <script src=""vendor/jquery-easing/jquery.easing.min.js""></script>

    <!-- Contact form JavaScript -->
    <script src=""js/jqBootstrapValidation.js""></script>
    <script src=""js/contact_me.js""></script>

    <!-- Custom ");
                WriteLiteral("scripts for this template -->\r\n    <script src=\"js/agency.min.js\"></script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Kursova.ViewModels.CourseProjects> Html { get; private set; }
    }
}
#pragma warning restore 1591
