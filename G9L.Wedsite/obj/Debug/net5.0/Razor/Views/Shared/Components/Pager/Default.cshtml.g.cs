#pragma checksum "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ede1fd18d3b3d0b1ef0f9c20ff0aee84fc8dacbf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Pager_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Pager/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ede1fd18d3b3d0b1ef0f9c20ff0aee84fc8dacbf", @"/Views/Shared/Components/Pager/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"579fbf2c77b709660bcb7e425e61592e3403d2bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Pager_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<G9L.Data.ViewModel.Common.PagedResultBase>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
  
    var urlTemplate = Url.Action() + "?pageIndex={0}";
    var request = ViewContext.HttpContext.Request;
    foreach (var key in request.Query.Keys)
    {
        if (key == "pageIndex")
        {
            continue;
        }
        if (request.Query[key].Count > 1)
        {
            foreach (var item in (string[])request.Query[key])
            {
                urlTemplate += "&" + key + "=" + item;
            }
        }
        else
        {
            urlTemplate += "&" + key + "=" + request.Query[key];
        }
    }

    var startIndex = Math.Max(Model.PageIndex - 5, 1);
    var finishIndex = Math.Min(Model.PageIndex + 5, Model.PageCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 28 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
 if (Model.PageCount > 1)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"card-footer py-4\">\r\n        <nav aria-label=\"...\">\r\n            <ul class=\"pagination justify-content-end mb-0\">\r\n");
#nullable restore
#line 33 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
                 if (Model.PageIndex != startIndex)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\">\r\n                        <a class=\"page-link\" title=\"1\"");
            BeginWriteAttribute("href", " href=\"", 1080, "\"", 1119, 1);
#nullable restore
#line 36 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1087, urlTemplate.Replace("{0}", "1"), 1087, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                            <i class=""fas fa-angle-left""></i>
                            <i class=""fas fa-angle-left""></i>
                        </a>
                    </li>
                    <li class=""page-item"">
                        <a class=""page-link""");
            BeginWriteAttribute("href", " href=\"", 1394, "\"", 1462, 1);
#nullable restore
#line 42 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1401, urlTemplate.Replace("{0}", (Model.PageIndex - 1).ToString()), 1401, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <i class=\"fas fa-angle-left\"></i>\r\n                        </a>\r\n                    </li>\r\n");
#nullable restore
#line 46 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
                 for (var i = startIndex; i <= finishIndex; i++)
                {
                    if (i == Model.PageIndex)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"page-item active\">\r\n                            <a class=\"page-link\" href=\"#\">");
#nullable restore
#line 52 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
                                                     Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"sr-only\">(current)</span></a>\r\n                        </li>\r\n");
#nullable restore
#line 54 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("title", " title=\"", 2089, "\"", 2116, 2);
            WriteAttributeValue("", 2097, "Trang", 2097, 5, true);
#nullable restore
#line 57 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue(" ", 2102, i.ToString(), 2103, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 2117, "\"", 2165, 1);
#nullable restore
#line 57 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 2124, urlTemplate.Replace("{0}", i.ToString()), 2124, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 57 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
                                                                                                                                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 58 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
                 if (Model.PageIndex != finishIndex)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\">\r\n                        <a class=\"page-link\"");
            BeginWriteAttribute("title", " title=\"", 2383, "\"", 2418, 1);
#nullable restore
#line 63 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 2391, Model.PageCount.ToString(), 2391, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 2419, "\"", 2487, 1);
#nullable restore
#line 63 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 2426, urlTemplate.Replace("{0}", (Model.PageIndex + 1).ToString()), 2426, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <i class=\"fas fa-angle-right\"></i>\r\n                        </a>\r\n                    </li>\r\n                    <li class=\"page-item\">\r\n                        <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2700, "\"", 2762, 1);
#nullable restore
#line 68 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 2707, urlTemplate.Replace("{0}", Model.PageCount.ToString()), 2707, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <i class=\"fas fa-angle-right\"></i>\r\n                            <i class=\"fas fa-angle-right\"></i>\r\n                        </a>\r\n                    </li>\r\n");
#nullable restore
#line 73 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </ul>\r\n        </nav>\r\n    </div>\r\n");
#nullable restore
#line 77 "E:\Garage 9 Lành\G9L\G9L.Wedsite\Views\Shared\Components\Pager\Default.cshtml"
 }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<G9L.Data.ViewModel.Common.PagedResultBase> Html { get; private set; }
    }
}
#pragma warning restore 1591
