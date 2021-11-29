﻿using System.Diagnostics;

namespace SFA.DAS.Employer.FrontDoor.Contentful.TestHarness.Model
{
    [DebuggerDisplay("{Name}")]
    public class SchemeLengthFilter : IFilter
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}