#pragma checksum "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9f715b082ca31345ce834e3f89574c9868981153"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f715b082ca31345ce834e3f89574c9868981153", @"/Views/Shared/_IndexProductsPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b87399f5c807f3a5f5539fe990a1e456104a3dd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__IndexProductsPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
            WriteLiteral("    <div data-aos-offset=\"100\"");
            BeginWriteAttribute("class", "\r\n         class=\"", 76, "\"", 294, 6);
            WriteAttributeValue("", 94, "product", 94, 7, true);
            WriteAttributeValue(" ", 101, "col-lg-3", 102, 9, true);
            WriteAttributeValue(" ", 110, "col-md-6", 111, 9, true);
            WriteAttributeValue(" ", 119, "popular", 120, 8, true);
            WriteAttributeValue(" ", 127, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#nullable restore
#line 4 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
                                                   foreach (var flowerCategory in flower.FlowerCategories)
                 {
                   

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
               Write(flowerCategory.Category.Name.ToLower()+" ");

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
                                                                
                 }

#line default
#line hidden
#nullable disable
                PopWriter();
            }
            ), 128, 162, false);
            WriteAttributeValue(" ", 290, "all", 291, 4, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"productImage\">\r\n");
#nullable restore
#line 9 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
             foreach (FlowerImage flowerImage in flower.FlowerImages)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <img");
            BeginWriteAttribute("src", " src=\"", 440, "\"", 464, 1);
#nullable restore
#line 11 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
WriteAttributeValue("", 446, flowerImage.Image, 446, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 465, "\"", 471, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 12 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n        <div class=\"productTitle\">\r\n            <p>");
#nullable restore
#line 17 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
          Write(flower.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n");
#nullable restore
#line 19 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
         if (flower.CampaignId == null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"productPrice\">\r\n                <span class=\"addToCardBtn\" data-id=\"1\">Add to cart</span><span>$</span><span>");
#nullable restore
#line 22 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
                                                                                        Write(flower.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n");
#nullable restore
#line 24 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"productPrice\">\r\n                <span class=\"addToCardBtn\" data-id=\"5\">Add to cart</span> <span style=\"text-decoration: line-through;\">$");
#nullable restore
#line 28 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
                                                                                                                   Write(flower.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                <span>$</span><span>");
#nullable restore
#line 29 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
                                Write(flower.Price * flower.Campaign.DiscountPercentage / 100);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n");
#nullable restore
#line 31 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"addToCart\">\r\n\r\n        </div>\r\n\r\n    </div>\r\n");
#nullable restore
#line 38 "C:\Users\MACBOOK\source\repos\FioreolloBack\FioreolloBack\Views\Shared\_IndexProductsPartialView.cshtml"
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
