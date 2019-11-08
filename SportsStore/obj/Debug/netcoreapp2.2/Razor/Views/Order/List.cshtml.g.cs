#pragma checksum "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\Order\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f211c071e142ac8429d8fea7f466e3fd83d16a27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_List), @"mvc.1.0.view", @"/Views/Order/List.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Order/List.cshtml", typeof(AspNetCore.Views_Order_List))]
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
#line 1 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\_ViewImports.cshtml"
using BuisnessLayer;

#line default
#line hidden
#line 2 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\_ViewImports.cshtml"
using BuisnessLayer.Entityes;

#line default
#line hidden
#line 3 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\_ViewImports.cshtml"
using BuisnessLayer.Models;

#line default
#line hidden
#line 4 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\_ViewImports.cshtml"
using BuisnessLayer.Infrastructure;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f211c071e142ac8429d8fea7f466e3fd83d16a27", @"/Views/Order/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"072b6c87c89ad87b31db40d83ec7f25c91ddcc17", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MarkShipped", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 2 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\Order\List.cshtml"
  
    ViewBag.Title = "Orders";
    Layout = "_AdminLayout";

#line default
#line hidden
            BeginContext(95, 125, true);
            WriteLiteral("    <table class=\"table table-bordered table-striped\">\r\n        <tr><th>Name</th><th colspan=\"2\">Details</th><th></th></tr>\r\n");
            EndContext();
#line 8 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\Order\List.cshtml"
         foreach (Order o in Model)
        {

#line default
#line hidden
            BeginContext(268, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(307, 6, false);
#line 11 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\Order\List.cshtml"
               Write(o.Name);

#line default
#line hidden
            EndContext();
            BeginContext(313, 98, true);
            WriteLiteral("</td>\r\n                <th>Product</th>\r\n                <th>Quantity</th>\r\n                <td>\r\n");
            EndContext();
#line 15 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\Order\List.cshtml"
                     if (!o.Shipped)
                    {   

#line default
#line hidden
            BeginContext(475, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(499, 324, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f211c071e142ac8429d8fea7f466e3fd83d16a275608", async() => {
                BeginContext(544, 65, true);
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"orderId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 609, "\"", 627, 1);
#line 18 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\Order\List.cshtml"
WriteAttributeValue("", 617, o.OrderID, 617, 10, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(628, 188, true);
                WriteLiteral(" />\r\n                            <button type=\"submit\" class=\"btn btn-sm btn-danger\">\r\n                                Ship\r\n                            </button>\r\n                        ");
                EndContext();
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
            EndContext();
            BeginContext(823, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 23 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\Order\List.cshtml"
                    } else
                    {

#line default
#line hidden
            BeginContext(876, 40, true);
            WriteLiteral("                        <p>Shipped</p>\r\n");
            EndContext();
#line 26 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\Order\List.cshtml"
                    }

#line default
#line hidden
            BeginContext(939, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 30 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\Order\List.cshtml"
             foreach (CartLine line in o.Lines)
            {

#line default
#line hidden
            BeginContext(1047, 77, true);
            WriteLiteral("                <tr>\r\n                    <td></td>\r\n                    <td>");
            EndContext();
            BeginContext(1125, 17, false);
#line 34 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\Order\List.cshtml"
                   Write(line.Product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1142, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1174, 13, false);
#line 35 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\Order\List.cshtml"
                   Write(line.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(1187, 61, true);
            WriteLiteral("</td>\r\n                    <td></td>\r\n                </tr>\r\n");
            EndContext();
#line 38 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\Order\List.cshtml"
            }

#line default
#line hidden
#line 38 "C:\Users\rogachov\Source\Repos\SportsShop\SportsStore\Views\Order\List.cshtml"
             
        }

#line default
#line hidden
            BeginContext(1274, 16, true);
            WriteLiteral("    </table>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591