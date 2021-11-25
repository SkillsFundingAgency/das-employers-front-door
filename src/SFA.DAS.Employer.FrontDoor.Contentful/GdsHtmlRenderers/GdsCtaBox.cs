﻿using Contentful.Core.Models;
using System.Text;
using System.Threading.Tasks;

namespace SFA.DAS.Employer.FrontDoor.Contentful.GdsHtmlRenderers
{
    /// <summary>
    /// A renderer for a call to action box.
    /// We re-appropriate block quotes from the rich text editor and turn them into call to action boxes.
    /// </summary>
    public class GdsCtaContentRenderer : IContentRenderer
    {
        private readonly ContentRendererCollection _rendererCollection;

        /// <summary>
        /// Initializes a new GdsCtaContentRenderer.
        /// </summary>
        /// <param name="rendererCollection">The collection of renderer to use for sub-content.</param>
        public GdsCtaContentRenderer(ContentRendererCollection rendererCollection)
        {
            _rendererCollection = rendererCollection;
        }

        /// <summary>
        /// The order of this renderer in the collection.
        /// </summary>
        public int Order { get; set; } = 50;

        /// <summary>
        /// Renders the content to a string.
        /// </summary>
        /// <param name="content">The content to render.</param>
        /// <returns>The list as a quote HTML string.</returns>
        public string Render(IContent content)
        {
            var quote = content as Quote;

            var sb = new StringBuilder();

            sb.Append("<div class=\"cx-cta-box\">");

            foreach (var subContent in quote!.Content)
            {
                var renderer = _rendererCollection.GetRendererForContent(subContent);
                sb.Append(renderer.Render(subContent));
            }

            sb.Append("</div>");

            return sb.ToString();
        }

        /// <summary>
        /// Whether or not this renderer supports the provided content.
        /// </summary>
        /// <param name="content">The content to evaluate.</param>
        /// <returns>Returns true if the content is a quote, otherwise false.</returns>
        public bool SupportsContent(IContent content)
        {
            return content is Quote;
        }

        /// <summary>
        /// Renders the content asynchronously.
        /// </summary>
        /// <param name="content">The content to render.</param>
        /// <returns>The rendered string.</returns>
        public Task<string> RenderAsync(IContent content)
        {
            return Task.FromResult(Render(content));
        }
    }

}
