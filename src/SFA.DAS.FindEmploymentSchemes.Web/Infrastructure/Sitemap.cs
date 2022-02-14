﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using AspNetCore.SEOHelper.Sitemap;
using SFA.DAS.FindEmploymentSchemes.Contentful.Services;
using Microsoft.Extensions.Options;

namespace SFA.DAS.FindEmploymentSchemes.Web.Infrastructure
{
    public class Sitemap : ISitemap
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IOptions<EndpointsOptions> _endpointsOptions;
        private readonly IContentService _contentService;

        public Sitemap(
            IWebHostEnvironment webHostEnvironment,
            IOptions<EndpointsOptions> endpointsOptions,
            IContentService contentService)
        {
            _webHostEnvironment = webHostEnvironment;
            _endpointsOptions = endpointsOptions;
            _contentService = contentService;
            contentService.ContentUpdated += OnContentUpdated;
        }

        private void OnContentUpdated(object? sender, EventArgs args)
        {
            Generate();
        }

        public void Generate()
        {
            if (!Uri.TryCreate(_endpointsOptions.Value.BaseURL, UriKind.Absolute, out Uri? baseUri))
                return;

            var nodes = new List<SitemapNode>();

            var content = _contentService.Content;

            nodes.AddRange(content.Schemes.Select(x => new SitemapNode {
                Priority = 1.0,
                Frequency = SitemapFrequency.Weekly,
                Url = new Uri(baseUri, string.Concat("schemes", x.Url.StartsWith("/") ? x.Url : $"/{x.Url}"))
                            .AbsoluteUri
            }));
            nodes.AddRange(content.Pages.Select(x => new SitemapNode
            {
                Priority = 1.0,
                Frequency = SitemapFrequency.Weekly,
                Url = new Uri(baseUri, string.Concat("page", x.Url.StartsWith("/") ? x.Url : $"/{x.Url}"))
                            .AbsoluteUri
            }));

            SitemapNode? home = nodes.FirstOrDefault(x => x.Url.EndsWith("/home"));
            if (home != null)
                home.Url = home.Url[..^9];

            new SitemapDocument().CreateSitemapXML(nodes, _webHostEnvironment.ContentRootPath);
        }
    }
}
