﻿using Contentful.Core.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SFA.DAS.FindEmploymentSchemes.Contentful.Model;
using SFA.DAS.FindEmploymentSchemes.Contentful.Model.Content;
using SFA.DAS.FindEmploymentSchemes.Web.Enums;
using SFA.DAS.FindEmploymentSchemes.Web.Interfaces;
using SFA.DAS.FindEmploymentSchemes.Web.References;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.FindEmploymentSchemes.Web.Services
{

    public static class InterimPageService
    {

        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private static ILogger _logger;

        private static IViewRenderService _viewRenderService;

        private static HtmlRenderer _htmlRenderer;

        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        #region Methods

        public static void Initialize(ILogger logger, IViewRenderService viewRenderService, HtmlRenderer htmlRenderer)
        {

            _logger = logger;

            _viewRenderService = viewRenderService;

            _htmlRenderer = htmlRenderer;

        }

        /// <summary>
        /// Private placeholder method for future expansion of interim components functionality and view building.
        /// </summary>
        /// <param name="scheme">Encapsulated scheme information.</param>
        /// <returns>Microsoft.AspNetCore.Mvc.Rendering.TagBuilder with pre rendered interim components.</returns>
        public static TagBuilder GenerateView(Scheme scheme)
        {

            return GenerateInterimPageAsync(scheme);

        }

        /// <summary>
        /// Private placeholder method for future expansion of interim components functionality.
        /// </summary>
        /// <param name="scheme">Encapsulated scheme information.</param>
        /// <returns>Microsoft.AspNetCore.Mvc.Rendering.TagBuilder with pre rendered interim components.</returns>
        private static TagBuilder GenerateInterimPageAsync(Scheme scheme)
        {

            return GenerateComponents(scheme);

        }

        /// <summary>
        /// Generate all interim components linked to a scheme.
        /// </summary>
        /// <param name="scheme">Encapsulated scheme information.</param>
        /// <returns>Microsoft.AspNetCore.Mvc.Rendering.TagBuilder with pre rendered interim components.</returns>
        private static TagBuilder GenerateComponents(Scheme scheme)
        {

            var pageLayoutRow = new TagBuilder("div");

            pageLayoutRow.AddCssClass($"{GovukReferences.GOVUK_GRID_ROW} {GovukReferences.PADDING_RIGHT_0}");

            foreach (InterimPageComponent component in scheme.Components)
            {

                GenerateComponent(component, pageLayoutRow);

            }

            return pageLayoutRow;

        }

        /// <summary>
        /// Dictionary or the purpose of mapping partial views to interim component types.
        /// </summary>
        private static readonly Dictionary<string, string> MappedTypesToPartials = new Dictionary<string, string>()
        {

            { InterimPageReferences.InterimContainerType, InterimPageReferences._InterimContainerPartial },

            { InterimPageReferences.InterimContentSectionsType, InterimPageReferences._ContentsSectionPartial },

            { InterimPageReferences.InterimVideoSectionType, InterimPageReferences._InterimVideoPartial },

            { InterimPageReferences.InterimCaseStudiesType, InterimPageReferences._InterimCaseStudiesPartial },

            { InterimPageReferences.InterimAccordionType, InterimPageReferences._InterimAccordionPartial }

        };

        /// <summary>
        /// Generate specified partial view via the component type property.
        /// </summary>
        /// <param name="component">Encapsulated information regarding the unique component object.</param>
        /// <param name="tag">Tag to append the rendered partial view to.</param>
        private static void GenerateComponent(InterimPageComponent component, TagBuilder tag)
        {

            try
            {

                var result = _viewRenderService.RenderToStringAsync(

                    MappedTypesToPartials[component.ComponentType ?? string.Empty],

                    component

                ).Result;

                tag.InnerHtml.AppendHtml(result);

            }
            catch(Exception _exception)
            {

                _logger.LogError(_exception, "Unable to generate componeont for type {ComponentType}.", component.ComponentType);

            }

        }

        /// <summary>
        /// Generate a SFA.DAS.FindEmploymentSchemes.Contentful.Model.InterimPageComponent sub component.
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        public static string GenerateSubComponent(InterimPageComponent component)
        {

            try
            {

                var result = _viewRenderService.RenderToStringAsync(

                    MappedTypesToPartials[component.ComponentType ?? string.Empty],

                    component

                ).Result;

                return result;

            }
            catch (Exception _exception)
            {

                _logger.LogError(_exception, "Unable to generate componeont for type {ComponentType}.", component.ComponentType);

                return string.Empty;

            }

        }

        /// <summary>
        /// Convert a long text html document to a html string.
        /// </summary>
        /// <param name="document">Contentful.Core.Models.Document object with encapsulated html node information.</param>
        /// <returns>Microsoft.AspNetCore.Html.HtmlString.</returns>
        public static HtmlString? ToHtmlString(Document? document)
        {
            if (document == null)
            {

                return null;

            }
                
            string html = _htmlRenderer.ToHtml(document).Result;

            return ToNormalisedHtmlString(html);

        }

        /// <summary>
        /// Normalize html string removed any new line or quotation marks.
        /// </summary>
        /// <param name="html">Prenormalized html string as string.</param>
        /// <returns>Microsoft.AspNetCore.Html.HtmlString.</returns>
        public static HtmlString ToNormalisedHtmlString(string html)
        {

            html = html.Replace('“', '"').Replace('”', '"');

            html = html.Replace("\r\n", "\r");

            html = html.Replace("\r", "\r\n");

            return new HtmlString(html);

        }

        #endregion

    }

}
