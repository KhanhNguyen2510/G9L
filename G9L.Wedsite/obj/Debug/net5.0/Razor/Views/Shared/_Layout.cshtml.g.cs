#pragma checksum "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c48bf2ad5593c949a4896b7dcee467eb51fea514"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\_ViewImports.cshtml"
using G9L.Wedsite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\_ViewImports.cshtml"
using G9L.Wedsite.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml"
using G9L.Common.SystemBase;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c48bf2ad5593c949a4896b7dcee467eb51fea514", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"579fbf2c77b709660bcb7e425e61592e3403d2bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("page-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c48bf2ad5593c949a4896b7dcee467eb51fea5143713", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"">
    <meta name=""description"" content=""Start your development with a Dashboard for Bootstrap 4."">
    <meta name=""author"" content=""Creative Tim"">
    <title>Garage 9 Lành</title>

    <link href=""vendor/fontawesome-free/css/all.min.css"" rel=""stylesheet"" type=""text/css"">
    <link href=""https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i""
          rel=""stylesheet"">

    <!-- Custom styles for this template-->
    <link href=""css/sb-admin-2.min.css"" rel=""stylesheet"">

    <style type='text/css'>

        table tr {
            counter-increment: Rownumber;
        }

        table td:first-child + td::before {
            content: counter(Rownumber);
        }
    </style>
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
            WriteLiteral("\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c48bf2ad5593c949a4896b7dcee467eb51fea5145593", async() => {
                WriteLiteral("\r\n    <!-- Sidenav -->\r\n    <div id=\"wrapper\">\r\n        ");
#nullable restore
#line 35 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml"
   Write(await Html.PartialAsync("_Sidebar"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <!-- Main content -->\r\n        <div id=\"content-wrapper\" class=\"d-flex flex-column\">\r\n            <!-- Main Content -->\r\n            <div id=\"content\">\r\n                ");
#nullable restore
#line 40 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml"
           Write(await Html.PartialAsync("_Header"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                <main>
                    <script>
                        setTimeout(function () {
                            $('#msgAlert').fadeOut('slow');
                        }, 600);
                    </script>
                    <div class=""row"" id=""msg"">
");
#nullable restore
#line 48 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml"
                         if (ViewBag.SuccessMessage != null)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <div id=""msgAlert"" class=""alert alert-success alert-dismissible fade show mt--6 ml-3 position-absolute opacity-8"" role=""alert"">
                                <span class=""alert-icon""> <i class=""fas fa-check-circle""></i></span>
                                <span class=""alert-text""><strong>");
#nullable restore
#line 52 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml"
                                                            Write(ViewBag.SuccessMessage);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong></span>
                                <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
                                    <span aria-hidden=""true"">&times;</span>
                                </button>
                            </div>
");
#nullable restore
#line 57 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml"
                         if (ViewBag.ErrorMessage != null)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <div id=""msgAlert"" class=""alert alert-danger alert-dismissible fade show  mt--6 ml-3 position-absolute opacity-8"" role=""alert"">
                                <span class=""alert-icon""><i class=""fas fa-exclamation-triangle""></i></span>
                                <span class=""alert-text""><strong> ");
#nullable restore
#line 62 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml"
                                                             Write(ViewBag.ErrorMessage);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong></span>
                                <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
                                    <span aria-hidden=""true"">&times;</span>
                                </button>
                            </div>
");
#nullable restore
#line 67 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </div>\r\n                </main>\r\n                <!-- Topnav -->\r\n                <div class=\"content-wrapper\">\r\n                    ");
#nullable restore
#line 73 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml"
               Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n            ");
#nullable restore
#line 76 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml"
       Write(await Html.PartialAsync("_Footer"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        </div>
    </div>
    <a class=""scroll-to-top rounded"" href=""#page-top"">
        <i class=""fas fa-angle-up""></i>
    </a>

    <script src=""vendor/jquery/jquery.min.js""></script>
    <script src=""vendor/bootstrap/js/bootstrap.bundle.min.js""></script>

    <!-- Core plugin JavaScript-->
    <script src=""vendor/jquery-easing/jquery.easing.min.js""></script>

    <!-- Custom scripts for all pages-->
    <script src=""js/sb-admin-2.min.js""></script>

    <!-- Page level plugins -->
    <script src=""vendor/chart.js/Chart.min.js""></script>

    <!-- Page level custom scripts -->
    <script src=""js/demo/chart-area-demo.js""></script>
    <script src=""js/demo/chart-pie-demo.js""></script>

    <script src=""https://kit.fontawesome.com/dcd92f06c4.js"" crossorigin=""anonymous""></script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
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
