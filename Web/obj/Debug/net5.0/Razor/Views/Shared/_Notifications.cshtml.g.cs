#pragma checksum "C:\Users\Sebastian\Desktop\Files\engee\Net core 5\Web\Views\Shared\_Notifications.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b06086d4c4c431dd7122f801b5f27bafcfdd6d33"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Notifications), @"mvc.1.0.view", @"/Views/Shared/_Notifications.cshtml")]
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
#line 1 "C:\Users\Sebastian\Desktop\Files\engee\Net core 5\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Sebastian\Desktop\Files\engee\Net core 5\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b06086d4c4c431dd7122f801b5f27bafcfdd6d33", @"/Views/Shared/_Notifications.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Notifications : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Web.ViewModels.Notification>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div id=\"divAlert\"");
            BeginWriteAttribute("class", " class=\"", 56, "\"", 117, 4);
            WriteAttributeValue("", 64, "alert", 64, 5, true);
            WriteAttributeValue(" ", 69, "notification", 70, 13, true);
            WriteAttributeValue(" ", 82, "fadeInOut-notification", 83, 23, true);
#nullable restore
#line 3 "C:\Users\Sebastian\Desktop\Files\engee\Net core 5\Web\Views\Shared\_Notifications.cshtml"
WriteAttributeValue(" ", 105, Model.Type, 106, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"alert\">\r\n    <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n        <span aria-hidden=\"true\">&times;</span>\r\n    </button>\r\n    <p id=\"alert-text\">\r\n        ");
#nullable restore
#line 8 "C:\Users\Sebastian\Desktop\Files\engee\Net core 5\Web\Views\Shared\_Notifications.cshtml"
   Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Web.ViewModels.Notification> Html { get; private set; }
    }
}
#pragma warning restore 1591
