﻿using System.Diagnostics;
using Contentful.Core.Models;

namespace SFA.DAS.FindEmploymentSchemes.Contentful.Model.Api
{
    [DebuggerDisplay("{Title}")]
    public class CaseStudyPage
    {
        public string? Title { get; set; }
        public string? Url { get; set; }
        public Document? Content { get; set; }
        public Scheme? Scheme { get; set; }
}
}