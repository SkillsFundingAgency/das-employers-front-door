﻿using Contentful.Core;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contentful.Core.Search;
using Contentful.Core.Models;
using Microsoft.AspNetCore.Html;
using SFA.DAS.FindEmploymentSchemes.Contentful.GdsHtmlRenderers;
using System;

namespace SFA.DAS.FindEmploymentSchemes.Contentful.Services
{
    public interface IContent
    {
        public IEnumerable<Model.Content.Page> Pages { get; set; }
    }

    public class Content : IContent
    {
        public Content(IEnumerable<Model.Content.Page> pages)
        {
            Pages = pages;
        }

        public IEnumerable<Model.Content.Page> Pages { get; set; }
    }

    public class ContentService : IContentService
    {
        private readonly IContentfulClient _contentfulClient;
        private readonly HtmlRenderer _htmlRenderer;

        private const string PayFilterPrefix = "pay";
        private const string MotivationsFilterPrefix = "motivations";
        private const string SchemeLengthFilterPrefix = "scheme-length";

        public ContentService(
            IContentfulClient contentfulClient,
            HtmlRenderer htmlRenderer)
        {
            _contentfulClient = contentfulClient;
            _htmlRenderer = htmlRenderer;
        }

        public async Task<IContent> Get()
        {
            return new Content(await GetPages());
        }

        private async Task<IEnumerable<Model.Content.Page>> GetPages()
        {
            var builder = QueryBuilder<Model.Api.Page>.New.ContentTypeIs("page");

            var apiPages = await _contentfulClient.GetEntries(builder);

            //todo: ctor to accept apipage??
            return await Task.WhenAll(apiPages.Select(ToContent));
        }

        private async Task<IEnumerable<Model.Content.Scheme>> GetSchemes()
        {
            var builder = QueryBuilder<Model.Api.Scheme>.New.ContentTypeIs("scheme").Include(1);

            var schemes = await _contentfulClient.GetEntries(builder);

            return await Task.WhenAll(schemes.OrderByDescending(s => s.Size).Select(ToContent));
        }

        private async Task<Model.Content.Page> ToContent(Model.Api.Page apiPage)
        {
            //todo: can any of these come through as null?
            return new Model.Content.Page(
                apiPage.Title!,
                apiPage.Url!,
                (await ToHtmlString(apiPage.Content))!);
        }

        private async Task<Model.Content.Scheme> ToContent(Model.Api.Scheme apiScheme)
        {
            return new Model.Content.Scheme(
                apiScheme.Name!,
                (await ToHtmlString(apiScheme.ShortDescription))!,
                (await ToHtmlString(apiScheme.ShortCost))!,
                (await ToHtmlString(apiScheme.ShortBenefits))!,
                (await ToHtmlString(apiScheme.ShortTime))!,
                apiScheme.Url!,
                apiScheme.Size,
                apiScheme.PayFilterAspects?.Select(f => ToFilterId(f, PayFilterPrefix)) ?? Enumerable.Empty<string>()
                    .Concat(apiScheme.MotivationsFilterAspects?.Select(f => ToFilterId(f, MotivationsFilterPrefix)) ?? Enumerable.Empty<string>())
                    .Concat(apiScheme.SchemeLengthFilterAspects?.Select(f => ToFilterId(f, SchemeLengthFilterPrefix)) ?? Enumerable.Empty<string>()),
                await ToHtmlString(apiScheme.DetailsPageOverride),
                await ToHtmlString(apiScheme.Description),
                await ToHtmlString(apiScheme.Cost),
                await ToHtmlString(apiScheme.Responsibility),
                await ToHtmlString(apiScheme.Benefits),
                await ToHtmlString(apiScheme.ShortBenefits),
                apiScheme.OfferHeader,
                await ToHtmlString(apiScheme.Offer));
        }

        private static string ToFilterId(Model.Api.IFilter filter, string filterPrefix)
        {
            return $"{filterPrefix}--{Slugify(filter.Name)}";
        }

        private static string Slugify(string? name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return name.ToLower().Replace(' ', '-');
        }

        //private static IEnumerable<string> GenerateFilterIds(IEnumerable<IFilter>? filters, string filterPrefix)
        //{
        //    if (filters == null)
        //        return Enumerable.Empty<string>();

        //    var filterIds = new StringBuilder();
        //    foreach (var filter in filters)
        //    {
        //        filterIds.Append($"\"{filterPrefix}--{Slugify(payFilter.Name)}\", ");
        //    }

        //    return filterIds.ToString();
        //}


        private async Task<HtmlString?> ToHtmlString(Document? document)
        {
            //todo: code gen needed to check null, check gen code to remember why
            if (document == null)
                return null;

            string unescapedHtml = await _htmlRenderer.ToHtml(document);

            // replace left/right quotation marks with regular old quotation marks
            string html = unescapedHtml.Replace('“', '"').Replace('”', '"');

            // sometimes contentful uses a \r and sometimes a \r\n - nice!
            // we could strip these out instead
            html = html.Replace("\r\n", "\r");
            html = html.Replace("\r", "\r\n");

            return new HtmlString(html);
        }

        public static HtmlRenderer CreateHtmlRenderer()
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

            return htmlRenderer;
        }
    }
}
