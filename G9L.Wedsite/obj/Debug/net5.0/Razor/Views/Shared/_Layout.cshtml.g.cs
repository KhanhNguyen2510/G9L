#pragma checksum "D:\G9L Manager\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "718e9c772b427284f17ae8dcba33cfe151c8ab84"
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
#line 1 "D:\G9L Manager\G9L\G9L.Wedsite\Views\_ViewImports.cshtml"
using G9L.Wedsite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\G9L Manager\G9L\G9L.Wedsite\Views\_ViewImports.cshtml"
using G9L.Wedsite.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml"
using G9L.Common.SystemBase;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"718e9c772b427284f17ae8dcba33cfe151c8ab84", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"579fbf2c77b709660bcb7e425e61592e3403d2bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ProductType", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Table", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Provider", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Manufacture", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Import", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "718e9c772b427284f17ae8dcba33cfe151c8ab846286", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"">
    <meta name=""description"" content=""Start your development with a Dashboard for Bootstrap 4."">
    <meta name=""author"" content=""Creative Tim"">
    <title>Argon Dashboard - Free Dashboard for Bootstrap 4</title>
    <!-- Favicon -->
    <link rel=""icon"" href=""../assets/img/brand/favicon.png"" type=""image/png"">
    <!-- Fonts -->
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/js/all.min.js""
            crossorigin=""anonymous""></script>
    <!-- Icons -->
    <link rel=""stylesheet"" href=""../assets/vendor/nucleo/css/nucleo.css"" type=""text/css"">
    <!-- Argon CSS -->
    <link rel=""stylesheet"" href=""../assets/css/argon.css?v=1.2.0"" type=""text/css"">
    <style type='text/css'>

        table tr {
            counter-increment: Rownumber;
        }

        table td:first-child + td::before {
            content: counter(Rownumber);
        }
  ");
                WriteLiteral("  </style>\r\n");
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "718e9c772b427284f17ae8dcba33cfe151c8ab848362", async() => {
                WriteLiteral(@"
    <!-- Sidenav -->
    <nav class=""sidenav navbar navbar-vertical  fixed-left  navbar-expand-xs navbar-light bg-white"" id=""sidenav-main"">
        <div class=""scrollbar-inner"">
            <!-- Brand -->
            <div class=""sidenav-header  align-items-center"">
                <a class=""navbar-brand"" href=""javascript:void(0)"">
                    <p class=""font-weight-bolder h1"">");
#nullable restore
#line 39 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml"
                                                Write(SystemConnection.NameCompany);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                </a>
            </div>
            <div class=""navbar-inner"">
                <!-- Collapse -->
                <div class=""collapse navbar-collapse"" id=""sidenav-collapse-main"">
                    <!-- Nav items -->
                    <ul class=""navbar-nav"">
                        <li class=""nav-item"">
                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "718e9c772b427284f17ae8dcba33cfe151c8ab849663", async() => {
                    WriteLiteral("\r\n                                <i class=\"ni ni-tv-2 text-primary\"></i>\r\n                                <span class=\"nav-link-text\">Thống kê</span>\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </li>\r\n                        <li class=\"nav-item\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "718e9c772b427284f17ae8dcba33cfe151c8ab8411479", async() => {
                    WriteLiteral("\r\n                                <i class=\"ni ni-box-2 text-orange\"></i>\r\n                                <span class=\"nav-link-text\">Sản Phẩm</span>\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </li>\r\n                        <li class=\"nav-item\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "718e9c772b427284f17ae8dcba33cfe151c8ab8413296", async() => {
                    WriteLiteral("\r\n                                <i class=\"ni ni-archive-2 text-primary\"></i>\r\n                                <span class=\"nav-link-text\">Loại Sản Phẩm</span>\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </li>\r\n                        <li class=\"nav-item\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "718e9c772b427284f17ae8dcba33cfe151c8ab8415123", async() => {
                    WriteLiteral("\r\n                                <i class=\"ni ni-single-02 text-default\"></i>\r\n                                <span class=\"nav-link-text\">Nhà Cung Cấp</span>\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </li>\r\n                        <li class=\"nav-item\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "718e9c772b427284f17ae8dcba33cfe151c8ab8416949", async() => {
                    WriteLiteral("\r\n                                <i class=\"ni ni-delivery-fast text-yellow \"></i>\r\n                                <span class=\"nav-link-text\">Nhà Sản Xuất</span>\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </li>\r\n                        <li class=\"nav-item\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "718e9c772b427284f17ae8dcba33cfe151c8ab8418779", async() => {
                    WriteLiteral("\r\n                                <i class=\"ni ni-cart text-info\"></i>\r\n                                <span class=\"nav-link-text\">Nhập Hàng</span>\r\n                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" href=""register.html"">
                                <i class=""ni ni-basket text-pink""></i>
                                <span class=""nav-link-text"">Bán Hàng</span>
                            </a>
                        </li>

                    </ul>
                    <!-- Divider -->
                    <hr class=""my-3"">
                </div>
                <!-- Heading -->
                <footer class="" mt-9"">
                    <div class=""row "">
                        <div class=""col-lg mt-9"">
                            &copy; 2022 Khánh Nguyên
                        </div>
                    </div>
                </footer>
            </div>
        </div>
    </nav>
    <!-- Main content -->
    <div class=""main-content"" id=""panel"">
        <!-- Topnav -->
        <nav class=""navbar navbar-top navbar-expand navbar-dark bg-primary borde");
                WriteLiteral(@"r-bottom"">
            <div class=""container-fluid"">
                <div class=""collapse navbar-collapse"" id=""navbarSupportedContent"">
                    <!-- Search form -->
                    <!-- Navbar links -->
                    <ul class=""navbar-nav align-items-center  ml-md-auto "">
                        <li class=""nav-item d-xl-none"">
                            <!-- Sidenav toggler -->
                            <div class=""pr-3 sidenav-toggler sidenav-toggler-dark"" data-action=""sidenav-pin""
                                 data-target=""#sidenav-main"">
                                <div class=""sidenav-toggler-inner"">
                                    <i class=""sidenav-toggler-line""></i>
                                    <i class=""sidenav-toggler-line""></i>
                                    <i class=""sidenav-toggler-line""></i>
                                </div>
                            </div>
                        </li>
                        <li class=""nav-it");
                WriteLiteral(@"em d-sm-none"">
                            <a class=""nav-link"" href=""#"" data-action=""search-show"" data-target=""#navbar-search-main"">
                                <i class=""ni ni-zoom-split-in""></i>
                            </a>
                        </li>
                    </ul>
                    <ul class=""navbar-nav align-items-center  ml-auto ml-md-0 "">
                        <li class=""nav-item dropdown"">
                            <a class=""nav-link pr-0"" href=""#"" role=""button"" data-toggle=""dropdown"" aria-haspopup=""true""
                               aria-expanded=""false"">
                                <div class=""media align-items-center"">
                                    <i class=""ni ni-circle-08"" style=""font-size: 38px;""></i>
                                    <div class=""media-body  ml-2  d-none d-lg-block"">
                                        <span class=""mb-0 text-sm  font-weight-bold"">Khanhnguyen@gmail.com</span>
                                    </div>
  ");
                WriteLiteral(@"                              </div>
                            </a>
                            <div class=""dropdown-menu  dropdown-menu-right "">
                                <div class=""dropdown-header noti-title"">
                                    <h6 class=""text-overflow m-0"">Chào bạn !</h6>
                                </div>
                                <a href=""#!"" class=""dropdown-item"">
                                    <i class=""ni ni-single-02""></i>
                                    <span>Thông tin cá nhân</span>
                                </a>
                                <a href=""#!"" class=""dropdown-item"">
                                    <i class=""ni ni-support-16""></i>
                                    <span>Đổi mật khẩu</span>
                                </a>
                                <div class=""dropdown-divider""></div>
                                <a href=""#!"" class=""dropdown-item"">
                                    <i class=""ni ni-u");
                WriteLiteral(@"ser-run""></i>
                                    <span>Đăng xuất</span>
                                </a>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <main>
            ");
#nullable restore
#line 166 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Shared\_Layout.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
        </main>
    </div>
    <!-- Argon Scripts -->
    <script src=""javascript.js""></script>
    <!-- Core -->
    <script src=""../assets/vendor/jquery/dist/jquery.min.js""></script>
    <script src=""../assets/vendor/bootstrap/dist/js/bootstrap.bundle.min.js""></script>
    <script src=""../assets/vendor/js-cookie/js.cookie.js""></script>
    <script src=""../assets/vendor/jquery.scrollbar/jquery.scrollbar.min.js""></script>
    <script src=""../assets/vendor/jquery-scroll-lock/dist/jquery-scrollLock.min.js""></script>
    <!-- Argon JS -->
    <script src=""../assets/js/argon.js?v=1.2.0""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/js/all.min.js"" crossorigin=""anonymous""></script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
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
