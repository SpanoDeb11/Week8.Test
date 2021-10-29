using AcademyG.Week8.Esercitazione.MVC.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8.Esercitazione.MVC.TagHelpers
{
    public class RestaurantTagHelper : TagHelper
    {
        public Restaurant Restaurant { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.SetHtmlContent(
                $@"<span itemprop=""name"">{Restaurant.Name}</span>
                <address itemprop=""address""><br/>
                <span itemprop=""streetAddress"">{Restaurant.StreetAddress}</span><br/>
                <span itemprop=""addressLocality"">{Restaurant.AddressLocality}</span><br/>
                <span itemprop=""streetRegion"">{Restaurant.AddressRegion}</span><br/>
                <span itemprop=""postalCode"">{Restaurant.PostalCode}</span>"
            );

            output.Attributes.SetAttribute("class", "row col-5");
        }
    }
}
