#pragma checksum "C:\riel\riel\riel\Views\Home\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "e63f9cc7101dfe9987be414adc2bc881e83dcaead794a445e280971c70137293"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\riel\riel\riel\Views\_ViewImports.cshtml"
using riel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\riel\riel\riel\Views\_ViewImports.cshtml"
using riel.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"e63f9cc7101dfe9987be414adc2bc881e83dcaead794a445e280971c70137293", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"e99b7de95f1bbb4a851eada93d22457bb05e7da0f99c01d5673cfe6ff72a999b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "About", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-custom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "C:\riel\riel\riel\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Головна";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<!DOCTYPE html>\n<html lang=\"uk\">\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e63f9cc7101dfe9987be414adc2bc881e83dcaead794a445e280971c701372934551", async() => {
                WriteLiteral("\n    <meta charset=\"UTF-8\">\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n    <title>");
#nullable restore
#line 178 "C:\riel\riel\riel\Views\Home\Index.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</title>

    <!-- Bootstrap CSS -->
    <link href=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"" rel=""stylesheet"">

    <style>
        /* Загальні стилі */
        body {
            font-family: Arial, sans-serif;
        }

        /* Герой-секція */
        .hero-section {
            background-image: url('images/fon.jpg');
            background-size: cover; /* Ensures the image covers the entire section */
            background-position: center; /* Centers the image within the section */
            background-repeat: no-repeat; /* Prevents image tiling */
            color: black;
            padding: 100px 0;
            text-align: center;
            height: 500px; /* Set a fixed height, adjust as needed */
        }

            .hero-section h1 {
                font-size: 54px;
                font-weight: bold;
            }

            .hero-section p {
                font-size: 20px;
            }

        .btn-custom {
            background-color: ");
                WriteLiteral(@"#ff5722;
            margin-top: 200px;
            color: #fff;
            padding: 12px 30px;
            border-radius: 30px;
        }

        /* Секція ""Про нас"" */
        .about-section {
            padding: 60px 0;
            background-color: #f9f9f9;
        }

            .about-section h2 {
                font-size: 36px;
                color: #333;
            }

            .about-section p {
                font-size: 18px;
                color: #555;
            }

        /* Секція ""Продукти"" */
        .products-section {
            padding: 60px 0;
            background-color: #fff;
        }

        .product-card {
            transition: transform 0.3s;
            border: 1px solid #ddd;
            border-radius: 10px;
            overflow: hidden;
            height: 350px;
            text-align: center;
        }

            .product-card img {
                width: 100%;
                height: 200px;
                object-fit: cover;
            }

           ");
                WriteLiteral(@" .product-card:hover {
                transform: scale(1.05);
                box-shadow: 0 8px 20px rgba(0, 0, 0, 0.15);
            }

        /* Секція ""Відгуки"" */
        .testimonials-section {
            background: #333;
            color: #fff;
            padding: 60px 0;
        }

        .testimonial {
            font-style: italic;
            font-size: 18px;
        }

        .customer-name {
            font-weight: bold;
            color: #ff5722;
        }
        /* Remove default link styling */
        .product-link {
            text-decoration: none;
            color: inherit; /* Inherit text color from the container */
            display: block; /* Make anchor fill the full column */
        }

            /* Optional: Add hover effect */
            .product-link:hover .product-card {
                box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2); /* Adds a shadow on hover */
                transform: scale(1.02); /* Slightly enlarges the card */
                trans");
                WriteLiteral(@"ition: transform 0.2s ease, box-shadow 0.2s ease;
            }
        /* Base link style */
        .product-link {
            text-decoration: none;
            color: inherit; /* Inherit text color from the surrounding elements */
        }

            /* Ensure link color remains consistent on all states */
            .product-link:link,
            .product-link:visited {
                color: inherit; /* Keeps the link color the same even after it’s visited */
            }

            .product-link:hover {
                color: inherit; /* Optional, keeps color the same on hover */
            }

                /* Optional: Add a hover effect without changing color */
                .product-link:hover .product-card {
                    box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2); /* Adds a shadow on hover */
                    transform: scale(1.02); /* Slightly enlarges the card */
                    transition: transform 0.2s ease, box-shadow 0.2s ease;
            ");
                WriteLiteral("    }\n\n\n    </style>\n");
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
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e63f9cc7101dfe9987be414adc2bc881e83dcaead794a445e280971c7013729310125", async() => {
                WriteLiteral("\n\n    <!-- Герой-секція -->\n    <div class=\"hero-section\">\n        <h1>Ласкаво просимо до Ріел Компанії</h1>\n        <p>Ми є лідерами в інноваційних рішеннях для кращого майбутнього.</p>\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e63f9cc7101dfe9987be414adc2bc881e83dcaead794a445e280971c7013729310607", async() => {
                    WriteLiteral("Дізнатись більше");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    </div>


    <!-- Секція ""Продукти"" -->
    <div class=""products-section"">
        <div class=""container"">
            <h2 class=""text-center"">Нерухомість</h2>
            <div class=""row mt-4"">
                <!-- Продукт 1 -->
                <div class=""col-md-4 mb-4"">
                    <a");
                BeginWriteAttribute("href", " href=\"", 13021, "\"", 13090, 1);
#nullable restore
#line 332 "C:\riel\riel\riel\Views\Home\Index.cshtml"
WriteAttributeValue("", 13028, Url.Action("Catalog", "Home", new { filterType = "Будинок" }), 13028, 62, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""product-link"">
                        <div class=""product-card"">
                            <img src=""images/ap2.jpeg"" alt=""Будинки"">
                            <div class=""p-3"">
                                <h5>Будинки</h5>
                                <p>Насолоджуйтесь комфортом, затишком та сучасними технологіями у вашому новому домі.</p>
                            </div>
                        </div>
                    </a>
                </div>
                <!-- Продукт 2 -->
                <div class=""col-md-4 mb-4"">
                    <a");
                BeginWriteAttribute("href", " href=\"", 13667, "\"", 13737, 1);
#nullable restore
#line 344 "C:\riel\riel\riel\Views\Home\Index.cshtml"
WriteAttributeValue("", 13674, Url.Action("Catalog", "Home", new { filterType = "Квартира" }), 13674, 63, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""product-link"">
                        <div class=""product-card"">
                            <img src=""images/ap3.webp"" alt=""Квартири"">
                            <div class=""p-3"">
                                <h5>Квартири</h5>
                                <p>Просторі та затишні квартири в сучасних комплексах з усіма зручностями.</p>
                            </div>
                        </div>
                    </a>
                </div>
                <!-- Продукт 3 -->
                <div class=""col-md-4 mb-4"">
                    <a");
                BeginWriteAttribute("href", " href=\"", 14305, "\"", 14375, 1);
#nullable restore
#line 356 "C:\riel\riel\riel\Views\Home\Index.cshtml"
WriteAttributeValue("", 14312, Url.Action("Catalog", "Home", new { filterType = "Комерція" }), 14312, 63, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""product-link"">
                        <div class=""product-card"">
                            <img src=""images/ap4.jpeg"" alt=""Комерційні приміщення"">
                            <div class=""p-3"">
                                <h5>Комерційні приміщення</h5>
                                <p>Ідеальне місце для розвитку вашого бізнесу з вигідним розташуванням і сучасними умовами.</p>
                            </div>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>


    <!-- Секція ""Відгуки"" -->
    <div class=""testimonials-section"">
        <div class=""container text-center"">
            <h2>Відгуки клієнтів</h2>
            <div class=""row mt-4"">
                <div class=""col-md-4"">
                    <p class=""testimonial"">""Ріель Компанія змінила нашу бізнес-операцію, привівши нас до нових рівнів ефективності та успіху!""</p>
                    <p class=""customer-name"">- Олексій Джонсон</p>
                </div>
      ");
                WriteLiteral(@"          <div class=""col-md-4"">
                    <p class=""testimonial"">""Їхні консалтингові послуги допомогли нам чітко визначити напрямок розвитку, що дозволило досягти результатів швидше.""</p>
                    <p class=""customer-name"">- Ліна Грін</p>
                </div>
                <div class=""col-md-4"">
                    <p class=""testimonial"">""Чудове обслуговування та підтримка. Ріель Компанія завжди поряд, коли ми потребуємо допомоги!""</p>
                    <p class=""customer-name"">- Сара Браун</p>
                </div>
            </div>
        </div>
    </div>

    <!-- Футер -->
    <footer class=""text-center py-4"">
        <p></p>
    </footer>

    <!-- Bootstrap JS -->
    <script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js""></script>
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
            WriteLiteral("\n</html>\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591