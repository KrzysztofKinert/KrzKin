#pragma checksum "C:\Users\Ja\Desktop\TrainSchedule\TrainSchedule\Pages\Components\CultureSwitcher\default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46287dbf4ff63d54c53ae70533cda308aa0ac098"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TrainSchedule.Pages.Components.CultureSwitcher.Pages_Components_CultureSwitcher_default), @"mvc.1.0.view", @"/Pages/Components/CultureSwitcher/default.cshtml")]
namespace TrainSchedule.Pages.Components.CultureSwitcher
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
#line 1 "C:\Users\Ja\Desktop\TrainSchedule\TrainSchedule\Pages\_ViewImports.cshtml"
using TrainSchedule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ja\Desktop\TrainSchedule\TrainSchedule\Pages\_ViewImports.cshtml"
using TrainSchedule.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Ja\Desktop\TrainSchedule\TrainSchedule\Pages\_ViewImports.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Ja\Desktop\TrainSchedule\TrainSchedule\Pages\_ViewImports.cshtml"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46287dbf4ff63d54c53ae70533cda308aa0ac098", @"/Pages/Components/CultureSwitcher/default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16e4b665146dcfa65908c90eca62c489544f8320", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Components_CultureSwitcher_default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CultureSwitcherModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div>\r\n    <div class=\"list-group list-group-horizontal list-group-item-primary bg-primary\" style=\"width: 150px\">\r\n");
#nullable restore
#line 4 "C:\Users\Ja\Desktop\TrainSchedule\TrainSchedule\Pages\Components\CultureSwitcher\default.cshtml"
         foreach (var culture in Model.SupportedCultures)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <button");
            BeginWriteAttribute("value", " value=\"", 233, "\"", 254, 1);
#nullable restore
#line 6 "C:\Users\Ja\Desktop\TrainSchedule\TrainSchedule\Pages\Components\CultureSwitcher\default.cshtml"
WriteAttributeValue("", 241, culture.Name, 241, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"culture\" id=\"culture-options\" class=\"btn bg-primary btn-primary\" style=\"padding: 0px; margin-right: 10px\">\r\n");
#nullable restore
#line 7 "C:\Users\Ja\Desktop\TrainSchedule\TrainSchedule\Pages\Components\CultureSwitcher\default.cshtml"
                 if (@culture.Name == "en-GB")
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("<img class=\"border border-white rounded\" onclick=\"cookieEN()\" src=\"/gb.svg\" style=\"width: 60px\" />");
#nullable restore
#line 8 "C:\Users\Ja\Desktop\TrainSchedule\TrainSchedule\Pages\Components\CultureSwitcher\default.cshtml"
                                                                                                                   }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <img class=\"border border-white rounded\" onclick=\"cookiePL()\" src=\"/pl.svg\" style=\"width: 60px\" />");
#nullable restore
#line 10 "C:\Users\Ja\Desktop\TrainSchedule\TrainSchedule\Pages\Components\CultureSwitcher\default.cshtml"
                                                                                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </button>\r\n");
#nullable restore
#line 12 "C:\Users\Ja\Desktop\TrainSchedule\TrainSchedule\Pages\Components\CultureSwitcher\default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>

<script type=""text/javascript"">
    function cookiePL() {
        document.cookie = "".AspNetCore.Culture=c=pl-PL|uic=pl-PL"";
        location.reload();
    };
    function cookieEN() {
        document.cookie = "".AspNetCore.Culture=c=en-GB|uic=en-GB"";
        location.reload();
    };
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CultureSwitcherModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
