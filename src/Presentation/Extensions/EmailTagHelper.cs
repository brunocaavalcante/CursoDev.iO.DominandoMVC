﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Extensions
{
    public class EmailTagHelper:TagHelper
    {
        public string EmailDomail { get; set; } = "desenvolvedor.io";

        public override async Task ProcessAsync(TagHelperContext context,TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@" + EmailDomail;
            output.Attributes.SetAttribute("href", "mailto" + target);
            output.Content.SetContent(target);
        }
    }
}
