﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Search;
using SFA.DAS.FindEmploymentSchemes.Contentful.ContentCodeGenerator.Model;
using SFA.DAS.FindEmploymentSchemes.Contentful.GdsHtmlRenderers;

namespace SFA.DAS.FindEmploymentSchemes.Contentful.ContentCodeGenerator
{
    internal class Program
    {
        private const string PayFilterPrefix = "pay";
        private const string MotivationsFilterPrefix = "motivations";
        private const string SchemeLengthFilterPrefix = "scheme-length";

        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var client = new ContentfulClient(httpClient,
                "",
                "",
                "082i50qdtar9");

            var htmlRenderer = CreateHtmlRenderer();

            Console.Write(Preamble());

            await GenerateSchemesContent(client, htmlRenderer);

            await GenerateFilterContent<MotivationsFilter>(client, "motivationsFilter", MotivationsFilterPrefix);
            await GenerateFilterContent<PayFilter>(client, "payFilter", PayFilterPrefix);
            await GenerateFilterContent<SchemeLengthFilter>(client, "schemeLengthFilter", SchemeLengthFilterPrefix);

            await GeneratePagesContent(client, htmlRenderer);

            Console.WriteLine(Closing());
        }

        private static async Task GeneratePagesContent(ContentfulClient client, HtmlRenderer htmlRenderer)
        {
            var builder = QueryBuilder<Page>.New.ContentTypeIs("page");

            var pages = await client.GetEntries<Page>(builder);

            Console.WriteLine(@"        public static readonly IEnumerable<Page> Pages = new[]
        {");

            foreach (Page page in pages)
            {
                Console.WriteLine($"new Page(\"{page.Title}\",");
                Console.WriteLine($"\"{page.Url}\",");
                Console.WriteLine($"{await AsHtmlString(page.Content, htmlRenderer)}");
                Console.WriteLine("),");
            }

            Console.WriteLine(@"        };");
        }

        private static async Task GenerateSchemesContent(ContentfulClient client, HtmlRenderer htmlRenderer)
        {
            var builder = QueryBuilder<Scheme>.New.ContentTypeIs("scheme").Include(1);

            var schemes = await client.GetEntries<Scheme>(builder);

            // ensure we order by size desc, so we don't have to sort at run time
            var schemesBiggestFirst = schemes.OrderByDescending(s => s.Size);

            Console.WriteLine(@"        public static readonly IEnumerable<Scheme> Schemes = new[]
        {
            // _    _                                _
            //| |  | |                              | |
            //| |__| | ___ _   _   _   _  ___  _   _| |
            //|  __  |/ _ \ | | | | | | |/ _ \| | | | |
            //| |  | |  __/ |_| | | |_| | (_) | |_| |_|
            //|_|  |_|\___|\__, |  \__, |\___/ \__,_(_)
            //              __/ |   __/ |
            //              |___/   |___/               
            //
            // these schemes are generated by the TestHarness from Contentful, so don't directly make changes here!!!
            //

            ");

            foreach (Scheme scheme in schemesBiggestFirst)
            {
                Console.WriteLine($"new Scheme(\"{scheme.Name}\",");
                Console.WriteLine($"{await AsHtmlString(scheme.ShortDescription, htmlRenderer)},");
                Console.WriteLine($"{await AsHtmlString(scheme.ShortCost, htmlRenderer)},");
                Console.WriteLine($"{await AsHtmlString(scheme.ShortBenefits, htmlRenderer)},");
                Console.WriteLine($"{await AsHtmlString(scheme.ShortTime, htmlRenderer)},");
                Console.WriteLine($"\"{scheme.Url}\", {scheme.Size},");

                Console.Write("new string[] {");
                Console.Write(GenerateFilterIds(scheme.PayFilterAspects, PayFilterPrefix));
                Console.Write(GenerateFilterIds(scheme.MotivationsFilterAspects, MotivationsFilterPrefix));
                Console.Write(GenerateFilterIds(scheme.SchemeLengthFilterAspects, SchemeLengthFilterPrefix));
                Console.WriteLine("},");
                Console.Write("new CaseStudy[] {");
                Console.Write(await GenerateCaseStudies(scheme.CaseStudyReferences, htmlRenderer));
                Console.WriteLine("},");

                Console.WriteLine($"{await AsHtmlString(scheme.DetailsPageOverride, htmlRenderer)},");
                Console.WriteLine($"{await AsHtmlString(scheme.Description, htmlRenderer)},");
                Console.WriteLine($"{await AsHtmlString(scheme.Cost, htmlRenderer)},");
                Console.WriteLine($"{await AsHtmlString(scheme.Responsibility, htmlRenderer)},");
                Console.WriteLine($"{await AsHtmlString(scheme.Benefits, htmlRenderer)},");
                Console.WriteLine($"\"{scheme.OfferHeader}\",");
                Console.WriteLine($"{await AsHtmlString(scheme.Offer, htmlRenderer)},");
                Console.WriteLine($"{await AsHtmlString(scheme.AdditionalFooter, htmlRenderer)}");
                Console.WriteLine("),");
            }

            Console.WriteLine(@"        };");
        }

        private static HtmlRenderer CreateHtmlRenderer()
        {
            var htmlRendererOptions = new HtmlRendererOptions
            {
                ListItemOptions =
                {
                    OmitParagraphTagsInsideListItems = true
                }
            };
            var htmlRenderer = new HtmlRenderer(htmlRendererOptions);
            htmlRenderer.AddRenderer(new GdsCtaContentRenderer(htmlRenderer.Renderers));
            htmlRenderer.AddRenderer(new GdsHeadingRenderer(htmlRenderer.Renderers));
            htmlRenderer.AddRenderer(new GdsHorizontalRulerContentRenderer());
            htmlRenderer.AddRenderer(new GdsHyperlinkContentRenderer(htmlRenderer.Renderers));
            htmlRenderer.AddRenderer(new GdsListContentRenderer(htmlRenderer.Renderers));
            htmlRenderer.AddRenderer(new GdsParagraphRenderer(htmlRenderer.Renderers));
            htmlRenderer.AddRenderer(new GdsEmbeddedYoutubeContentRenderer(htmlRenderer.Renderers));
            return htmlRenderer;
        }

        private static string GenerateFilterIds(IEnumerable<IFilter>? filters, string filterPrefix)
        {
            if (filters == null)
                return "";

            var filterIds = new StringBuilder();
            foreach (var payFilter in filters)
            {
                filterIds.Append($"\"{filterPrefix}--{Slugify(payFilter.Name)}\", ");
            }

            return filterIds.ToString();
        }

        private static async Task<string> GenerateCaseStudies(IEnumerable<CaseStudy>? caseStudies, HtmlRenderer htmlRenderer)
        {
            if (caseStudies == null)
                return "";

            StringBuilder sb = new StringBuilder();
            foreach (CaseStudy cs in caseStudies)
            {
                sb.Append($"new CaseStudy(\"{cs.Name}\", \"{cs.DisplayTitle}\", ");
                sb.Append($"{await AsHtmlString(cs.Description, htmlRenderer)}), ");
            }

            return sb.ToString();
        }

        private static async Task GenerateFilterContent<T>(ContentfulClient client, string filterContentfulTypeName, string filterPrefix)
        where T : IFilter
        {
            var builder = QueryBuilder<T>.New.ContentTypeIs(filterContentfulTypeName);

            var filters = await client.GetEntries<T>(builder);

            var orderedFilters = filters.OrderBy(f => f.Order);

            string filterTypeName = typeof(T).Name;

            Console.WriteLine(@$"        public static readonly IEnumerable<{filterTypeName}> {filterTypeName}s = new {filterTypeName}[]
            {{
                ");

            foreach (T filter in orderedFilters)
            {
                Console.WriteLine($"new {typeof(T).Name}(\"{filterPrefix}--{Slugify(filter.Name)}\",");
                Console.WriteLine($"\"{filter.Description}\"");
                Console.WriteLine("),");
            }

            Console.WriteLine("        };");
        }

        private static string Slugify(string? name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return name.ToLower().Replace(' ', '-');
        }

        private static string Preamble()
        {
            return @"using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using SFA.DAS.FindEmploymentSchemes.Web.Models;

namespace SFA.DAS.FindEmploymentSchemes.Web.Content
{
    public static class SchemesContent
    {";
        }

        private static string Closing()
        {
            return @"    }
}";
        }

        //todo: empty strings as nulls?

        private static async Task<string> AsHtmlString(Document? document, HtmlRenderer htmlRenderer)
        {
            if (document == null)
                return "null";

            string unescapedHtml = await htmlRenderer.ToHtml(document);
            string html = unescapedHtml.Replace("\"", "\"\"");
            html = html.Replace("“", "\"\"");
            html = html.Replace("”", "\"\"");
            // sometimes contentful uses a \r and sometimes a \r\n - nice!
            // we could strip these out instead
            html = html.Replace("\r\n", "\r");
            html = html.Replace("\r", "\r\n");

            return $"new HtmlString(@\"{html}\")";
        }
    }
}
