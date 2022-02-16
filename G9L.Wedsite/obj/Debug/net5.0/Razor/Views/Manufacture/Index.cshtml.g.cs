#pragma checksum "D:\G9L Manager\G9L\G9L.Wedsite\Views\Manufacture\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5cfde9e2c27cabfcff2d4b185501755657e53919"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manufacture_Index), @"mvc.1.0.view", @"/Views/Manufacture/Index.cshtml")]
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
#line 1 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Manufacture\Index.cshtml"
using G9L.Data.ViewModel.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Manufacture\Index.cshtml"
using G9L.Common.SystemBase;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5cfde9e2c27cabfcff2d4b185501755657e53919", @"/Views/Manufacture/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"579fbf2c77b709660bcb7e425e61592e3403d2bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Manufacture_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedResult<G9L.Data.ViewModel.Catalog.Mannufacture.GetManufactureViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Manufacture\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<main>
    <div class=""header bg-primary pb-6"">
        <div class=""container-fluid"">
            <div class=""header-body"">
                <div class=""row align-items-center py-4"">
                    <div class=""col-lg-6 col-7"">
                        <nav aria-label=""breadcrumb"" class=""d-none d-md-inline-block ml-md-4"">
                            <ol class=""breadcrumb breadcrumb-links breadcrumb-dark"">
                                <li class=""breadcrumb-item""><a href=""#""><i class=""fas fa-home""></i></a></li>
                                <li class=""breadcrumb-item active"" aria-current=""page"">Danh sách nhà sản xuất</li>
                            </ol>
                        </nav>
                    </div>
                    <div class=""col-lg-6 col-5 text-right"">

                        <button type=""button"" class=""btn btn-sm btn-neutral"" data-toggle=""modal"" data-target=""#modal-form"">
                            Thêm
                        </button>
                        <bu");
            WriteLiteral(@"tton id=""deleteByID"" class=""btn btn-sm text-white"" onclick=""deleteID()"" style=""background-color:#f5365c;"" disabled>Xóa</button>
                    </div>
                </div>
            </div>
        </div>
        <div class=""container-fluid"">
            <div class=""header-body"">
                <div class=""row align-items-center"">
                    <div class=""col-lg-3 col-7"">
                        <div class=""form-group"">
                            <label for=""example-search-input"" class=""form-control-label text-white"">Tìm kiếm</label>
                            <input class=""form-control"" type=""search"" placeholder=""Bạn cần tìm gì..........."">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <style type='text/css'>
        table { <!--
            from w w w. jav a 2 s .c o m--> counter-reset: rowNumber;
        }

            table tr {
                counter-inc");
            WriteLiteral(@"rement: rowNumber;
            }

                table tr td:first-child::before {
                    content: counter(rowNumber);
                    min-width: 1em;
                    margin-right: 0.5em;
                }
    </style>
    <div class=""container-fluid mt--6"">
        <div class=""row"">
            <div class=""col"">
                <div class=""card"">
                    <!-- Card header -->
                    <div class=""card-header border-0"">
                        <h3 class=""mb-0"">Nhà cung cấp</h3>
                    </div>
                    <!-- Light table -->
                    <div class=""table-responsive"">
                        <table class=""table align-items-center table-flush"">
                            <thead class=""thead-light"">
                                <tr>
                                    <th scope=""col"" class=""sort text-center"">
                                        <input type=""checkbox"">
                                    </th>");
            WriteLiteral(@"
                                    <th scope=""col"" class=""sort"" data-sort=""budget"">STT</th>
                                    <th scope=""col"" class=""sort"" data-sort=""name"">Tên</th>
                                    <th scope=""col"" class=""sort"" data-sort=""name"">Địa chỉ</th>
                                    <th scope=""col"" class=""sort"" data-sort=""budget"">Ngày tạo</th>
                                    <th scope=""col"" class=""sort"" data-sort=""status"">Người tạo</th>
                                    <th scope=""col""></th>
                                </tr>
                            </thead>
                            <tbody class=""list"">

");
#nullable restore
#line 87 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Manufacture\Index.cshtml"
                                 foreach (var item in Model.Items)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <th class=\"text-center\">\r\n                                            <input type=\"checkbox\"");
            BeginWriteAttribute("id", " id=\"", 4258, "\"", 4282, 1);
#nullable restore
#line 91 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Manufacture\Index.cshtml"
WriteAttributeValue("", 4263, item.ManufactureID, 4263, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onchange", " onchange=\"", 4283, "\"", 4329, 3);
            WriteAttributeValue("", 4294, "addIDToArray(\'", 4294, 14, true);
#nullable restore
#line 91 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Manufacture\Index.cshtml"
WriteAttributeValue("", 4308, item.ManufactureID, 4308, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4327, "\')", 4327, 2, true);
            EndWriteAttribute();
            WriteLiteral(@">
                                        </th>
                                        <td >

                                        </td>
                                        <th scope=""row"">
                                            <div class=""media align-items-center"">
                                                <div class=""media-body"">
                                                    <span class=""name mb-0 text-sm"">");
#nullable restore
#line 99 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Manufacture\Index.cshtml"
                                                                               Write(Html.DisplayFor(modelItem => item.ManufactureName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                                                </div>
                                            </div>
                                        </th>
                                        <td class=""budget"">
                                            ");
#nullable restore
#line 104 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Manufacture\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Local));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td class=\"budget\">\r\n                                            ");
#nullable restore
#line 107 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Manufacture\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.UpdateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td class=\"budget\">\r\n                                            ");
#nullable restore
#line 110 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Manufacture\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.UpdateUser));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </td>

                                        <td class=""text-right"">
                                            <button type=""button"" class=""btn btn-sm btn-icon-only text-light"" data-toggle=""modal""
                                                    data-target=""#modal-notification"">
                                                <i class=""fas fa-ellipsis-v""></i>
                                            </button>
                                        </td>
                                    </tr>
");
#nullable restore
#line 120 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Manufacture\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                    <!-- Card footer -->\r\n                    ");
#nullable restore
#line 126 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Manufacture\Index.cshtml"
               Write(await Component.InvokeAsync("Pager", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </div>
            </div>
        </div>
    </div>
    <!-- Create content -->
    <div class=""modal fade"" id=""modal-form"" tabindex=""-1"" role=""dialog"" aria-labelledby=""modal-form"" aria-hidden=""true"">
        <div class=""modal-dialog modal- modal-dialog-centered modal-sm"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-body p-0"">
                    <div class=""card bg-secondary border-0 mb-0"">
                        <div class=""modal-header"">
                            <h6 class=""modal-title"" id=""modal-title-notification"">Thêm nhà sản xuất</h6>
                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                <span aria-hidden=""true"">×</span>
                            </button>
                        </div>
                        <div class=""card-body px-lg-3 py-lg-5"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cfde9e2c27cabfcff2d4b185501755657e5391913813", async() => {
                WriteLiteral(@"
                                <div class=""form-group mb-5"">
                                    <div class=""input-group"">
                                        <div class=""input-group-prepend"">
                                            <span class=""input-group-text"" id=""inputGroup-sizing-default"">Tên nhà sản xuất</span>
                                        </div>
                                        <input type=""text"" class=""form-control"" aria-label=""Sizing example input"" aria-describedby=""inputGroup-sizing-default"">
                                    </div>
                                </div>
                                <div class=""form-group "">
                                    <div class=""input-group"">
                                        <div class=""input-group-prepend"">
                                            <span class=""input-group-text"" id=""inputGroup-sizing-default"">Địa chỉ</span>
                                        </div>
                              ");
                WriteLiteral(@"          <input type=""text"" class=""form-control"" aria-label=""Sizing example input"" aria-describedby=""inputGroup-sizing-default"">
                                    </div>
                                </div>

                                <div class=""text-center"">
                                    <button type=""button"" class=""btn btn-primary"">Thêm</button>
                                </div>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
                </div>
            </div>
        </div>
    </div>
    <!-- Update content -->
    <div class=""modal fade"" id=""modal-notification"" tabindex=""-1"" role=""dialog"" aria-labelledby=""modal-notification"" aria-hidden=""true"">
        <div class=""modal-dialog modal- modal-dialog-centered modal-sm"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-body p-0"">
                    <div class=""card bg-secondary border-0 mb-0"">
                        <div class=""modal-header"">
                            <h6 class=""modal-title"" id=""modal-title-notification"">Chỉnh sửa nhà sản xuất</h6>
                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                <span aria-hidden=""true"">×</span>
                            </button>
                        </div>
                        <div class=""card-body px-lg-3 py-lg-5"">
       ");
            WriteLiteral("                     ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cfde9e2c27cabfcff2d4b185501755657e5391917781", async() => {
                WriteLiteral(@"
                                <div class=""form-group mb-5"">
                                    <div class=""input-group"">
                                        <div class=""input-group-prepend"">
                                            <span class=""input-group-text"" id=""inputGroup-sizing-default"">Tên nhà sản xuất</span>
                                        </div>
                                        <input type=""text"" class=""form-control"" aria-label=""Sizing example input"" aria-describedby=""inputGroup-sizing-default"">
                                    </div>
                                </div>
                                <div class=""form-group"">
                                    <div class=""input-group"">
                                        <div class=""input-group-prepend"">
                                            <span class=""input-group-text"" id=""inputGroup-sizing-default"">Địa chỉ</span>
                                        </div>
                               ");
                WriteLiteral(@"         <input type=""text"" class=""form-control"" aria-label=""Sizing example input"" aria-describedby=""inputGroup-sizing-default"">
                                    </div>
                                </div>
                                <div class=""text-center"">
                                    <button type=""button"" class=""btn btn-primary"">Cập nhật</button>
                                </div>
                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</main>\r\n<script>\r\n   BaseLocalhost = \'");
#nullable restore
#line 214 "D:\G9L Manager\G9L\G9L.Wedsite\Views\Manufacture\Index.cshtml"
               Write(SystemConnection.UploadImageConnection);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'

    listID = [];

    function deleteItemInArray(arr, item) {
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] === item) {
                arr.splice(i, 1);
                i--;
            }
        }
    };

    function findID(arr, item) {
        for (var i = 0; i < arr.length; i++) {
            if (arr[i] === item) {
                return true;
            }
        }
    };

    function toggleButton() {
        if (listID.length == 0) {
            $('#deleteByID').prop('disabled', true);
        } else {
            $('#deleteByID').prop('disabled', false);
        }
    };

    function addIDToArray(ID) {
        if (!findID(listID, ID)) {
            listID.push(ID);

            console.log(listID)

        } else {
            deleteItemInArray(listID, ID);
        }
        toggleButton()
    };

    async function deletePost() {
        for (var i = 0; i < listID.length; i++) {
            await $.ajax({
                url: B");
            WriteLiteral(@"aseLocalhost + '/api/Manufacture/DeleteToManufacture/' + listID[i],
                type: 'POST',
                dataType: 'json',
                success: function (data) {
                    alert('Thanh cong')
                },
                error: function () {
                    console.log('Connect failled');
                },
            });
        }
        location.reload();
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedResult<G9L.Data.ViewModel.Catalog.Mannufacture.GetManufactureViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
