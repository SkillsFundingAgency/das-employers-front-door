﻿using Contentful.Core;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.FindEmploymentSchemes.Contentful.Services
{
    public class ContentfulClientFactory : IContentfulClientFactory
    {
        public IContentfulClient? ContentfulClient { get; }
        public IContentfulClient? PreviewContentfulClient { get; }

        public ContentfulClientFactory(IEnumerable<IContentfulClient> contentfulClients)
        {
            ContentfulClient = contentfulClients.SingleOrDefault(c => !c.IsPreviewClient);
            PreviewContentfulClient = contentfulClients.SingleOrDefault(c => c.IsPreviewClient);
        }
    }
}
