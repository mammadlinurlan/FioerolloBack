#pragma checksum "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ad9eb4a07a72ab2da99cfb727dd4fa242c8c010e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__IndexProductsPartialView), @"mvc.1.0.view", @"/Views/Shared/_IndexProductsPartialView.cshtml")]
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
#line 1 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\_ViewImports.cshtml"
using FioreolloBack;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\_ViewImports.cshtml"
using FioreolloBack.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\_ViewImports.cshtml"
using FioreolloBack.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad9eb4a07a72ab2da99cfb727dd4fa242c8c010e", @"/Views/Shared/_IndexProductsPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b87399f5c807f3a5f5539fe990a1e456104a3dd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__IndexProductsPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Flower", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-aos-offset", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
 foreach (Flower flower in Model.Flowers)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad9eb4a07a72ab2da99cfb727dd4fa242c8c010e4578", async() => {
                WriteLiteral("\r\n\r\n        <div>\r\n\r\n        <div class=\"productImage\">\r\n");
#nullable restore
#line 13 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
             foreach (FlowerImage flowerImage in flower.FlowerImages.Where(i=>i.IsMain==true))
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <img");
                BeginWriteAttribute("src", " src=\"", 556, "\"", 580, 1);
#nullable restore
#line 15 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
WriteAttributeValue("", 562, flowerImage.Image, 562, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 581, "\"", 587, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 16 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        </div>\r\n        <div class=\"productTitle\">\r\n            <p>");
#nullable restore
#line 21 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
          Write(flower.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        </div>\r\n");
#nullable restore
#line 23 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
         if (flower.CampaignId == null)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"productPrice\">\r\n                <span class=\"addToCardBtn\" data-id=\"1\">Add to cart</span><span>$</span><span>");
#nullable restore
#line 26 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
                                                                                        Write(flower.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n            </div>\r\n");
#nullable restore
#line 28 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"productPrice\">\r\n                <span class=\"addToCardBtn\" data-id=\"5\">Add to cart</span> <span style=\"text-decoration: line-through;\">$");
#nullable restore
#line 32 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
                                                                                                                   Write(flower.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                <span>$</span><span>");
#nullable restore
#line 33 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
                                Write(flower.Price * flower.Campaign.DiscountPercentage / 100);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n            </div>\r\n");
#nullable restore
#line 35 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        <div class=\"addToCart\">\r\n\r\n        </div>\r\n\r\n\r\n\r\n            </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 4 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
                                                       WriteLiteral(flower.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 6, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 166, "product", 166, 7, true);
            AddHtmlAttributeValue(" ", 173, "col-lg-3", 174, 9, true);
            AddHtmlAttributeValue(" ", 182, "col-md-6", 183, 9, true);
            AddHtmlAttributeValue(" ", 191, "popular", 192, 8, true);
            AddHtmlAttributeValue(" ", 199, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#nullable restore
#line 5 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
                                                   foreach (var flowerCategory in flower.FlowerCategories)
                 {
                   

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
               Write(flowerCategory.Category.Name.ToLower()+" ");

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
                                                                
                 }

#line default
#line hidden
#nullable disable
                PopWriter();
            }
            ), 200, 162, false);
            AddHtmlAttributeValue(" ", 362, "all", 363, 4, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 45 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"

   
}

#line default
#line hidden
#nullable disable
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
