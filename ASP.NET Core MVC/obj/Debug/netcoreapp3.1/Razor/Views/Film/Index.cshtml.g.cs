#pragma checksum "D:\andersen\ASP.NET Core MVC\ASP.NET Core MVC\Views\Film\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b33575aeb4f448d4e817203649d42516de4c96f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Film_Index), @"mvc.1.0.view", @"/Views/Film/Index.cshtml")]
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
#line 1 "D:\andersen\ASP.NET Core MVC\ASP.NET Core MVC\Views\_ViewImports.cshtml"
using ASP.NET_Core_MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\andersen\ASP.NET Core MVC\ASP.NET Core MVC\Views\_ViewImports.cshtml"
using ASP.NET_Core_MVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b33575aeb4f448d4e817203649d42516de4c96f", @"/Views/Film/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7efaf91dce81bddc7014c380b11138873f87db74", @"/Views/_ViewImports.cshtml")]
    public class Views_Film_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ASP.NET_Core_MVC.Models.Film>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\andersen\ASP.NET Core MVC\ASP.NET Core MVC\Views\Film\Index.cshtml"
  
    ViewData["Title"] = "Фильмы";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Фильмы</h1>
    <table class=""tabble"">
        <tr>
            <td>ID</td>
            <td>Title</td>
            <td>Year</td>
            <td>Time</td>
            <td>Age</td>
            <td>Rating</td>
            <td>Trailer</td>
        </tr>
");
#nullable restore
#line 18 "D:\andersen\ASP.NET Core MVC\ASP.NET Core MVC\Views\Film\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 21 "D:\andersen\ASP.NET Core MVC\ASP.NET Core MVC\Views\Film\Index.cshtml"
               Write(Html.DisplayTextFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 22 "D:\andersen\ASP.NET Core MVC\ASP.NET Core MVC\Views\Film\Index.cshtml"
               Write(Html.DisplayTextFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "D:\andersen\ASP.NET Core MVC\ASP.NET Core MVC\Views\Film\Index.cshtml"
               Write(Html.DisplayTextFor(modelItem => item.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "D:\andersen\ASP.NET Core MVC\ASP.NET Core MVC\Views\Film\Index.cshtml"
               Write(Html.DisplayTextFor(modelItem => item.Time));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "D:\andersen\ASP.NET Core MVC\ASP.NET Core MVC\Views\Film\Index.cshtml"
               Write(Html.DisplayTextFor(modelItem => item.Age));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "D:\andersen\ASP.NET Core MVC\ASP.NET Core MVC\Views\Film\Index.cshtml"
               Write(Html.DisplayTextFor(modelItem => item.Rating));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "D:\andersen\ASP.NET Core MVC\ASP.NET Core MVC\Views\Film\Index.cshtml"
               Write(Html.DisplayTextFor(modelItem => item.Trailer));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 29 "D:\andersen\ASP.NET Core MVC\ASP.NET Core MVC\Views\Film\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </table>\r\n");
            WriteLiteral("  \r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ASP.NET_Core_MVC.Models.Film>> Html { get; private set; }
    }
}
#pragma warning restore 1591
