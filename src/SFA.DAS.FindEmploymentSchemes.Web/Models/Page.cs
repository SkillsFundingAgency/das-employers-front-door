﻿using Microsoft.AspNetCore.Html;

namespace SFA.DAS.FindEmploymentSchemes.Web.Models
{
    public class Page
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public IHtmlContent Content { get; set; }

        public Page(string title, string url, IHtmlContent content)
        {
            Title = title;
            Url = url;
            Content = content;
        }
    }
}