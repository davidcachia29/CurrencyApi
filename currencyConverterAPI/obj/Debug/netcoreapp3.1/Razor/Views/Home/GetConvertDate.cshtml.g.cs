#pragma checksum "E:\Interview Program\currencyConverterAPI\currencyConverterAPI\Views\Home\GetConvertDate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8a0c9dccca018d7e65dcae62922124158f3eb09f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GetConvertDate), @"mvc.1.0.view", @"/Views/Home/GetConvertDate.cshtml")]
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
#line 1 "E:\Interview Program\currencyConverterAPI\currencyConverterAPI\Views\_ViewImports.cshtml"
using APIConsume.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a0c9dccca018d7e65dcae62922124158f3eb09f", @"/Views/Home/GetConvertDate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ad71e7aaf8df096cf3bd076ea4d23ca580ef717", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GetConvertDate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CurrencyData>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Interview Program\currencyConverterAPI\currencyConverterAPI\Views\Home\GetConvertDate.cshtml"
   Layout = "_Layout"; ViewBag.Title = "All Reservations";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2>Currency Converter API</h2>
<h2>Getting Basic Data</h2>
<br />
<br />
<table class=""table table-sm table-striped table-bordered m-2"">
    <thead>
        <tr>
            <th>Successful</th>
            <th>TimeStamp</th>
            <th>Date</th>
            <th>Base</th>
            <th>Rates</th>

        </tr>
    </thead>
    <tbody>
        <tr>
            <td>");
#nullable restore
#line 21 "E:\Interview Program\currencyConverterAPI\currencyConverterAPI\Views\Home\GetConvertDate.cshtml"
           Write(Model.success);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 22 "E:\Interview Program\currencyConverterAPI\currencyConverterAPI\Views\Home\GetConvertDate.cshtml"
           Write(Model.timestamp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 23 "E:\Interview Program\currencyConverterAPI\currencyConverterAPI\Views\Home\GetConvertDate.cshtml"
           Write(Model.date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 24 "E:\Interview Program\currencyConverterAPI\currencyConverterAPI\Views\Home\GetConvertDate.cshtml"
            Write(Model.@base);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 26 "E:\Interview Program\currencyConverterAPI\currencyConverterAPI\Views\Home\GetConvertDate.cshtml"
             if (Model.rates == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>Error</td>\r\n");
#nullable restore
#line 29 "E:\Interview Program\currencyConverterAPI\currencyConverterAPI\Views\Home\GetConvertDate.cshtml"
            }
            else
            {
                foreach (var r in Model.rates)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>");
#nullable restore
#line 34 "E:\Interview Program\currencyConverterAPI\currencyConverterAPI\Views\Home\GetConvertDate.cshtml"
                   Write(r);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 35 "E:\Interview Program\currencyConverterAPI\currencyConverterAPI\Views\Home\GetConvertDate.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n        </tr>\r\n\r\n    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CurrencyData> Html { get; private set; }
    }
}
#pragma warning restore 1591
