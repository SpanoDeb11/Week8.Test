using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8.Esercitazione.MVC.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string ToUser { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetHtmlContent(
                $@"<a class=""btn btn-info"" href=""mailto:{ToUser}"">Contattaci!</a>"
            );

            output.Attributes.SetAttribute("class", "nav-item");
        }
    }
}
