﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using SFA.DAS.FindEmploymentSchemes.Contentful.Model.Interim;

namespace SFA.DAS.FindEmploymentSchemes.Contentful.Model.Content
{
    public class Scheme
    {
        /// <summary>
        /// Should always be valid. We filter out schemes with invalid urls, as they aren't navigable.
        /// </summary>
        public string Url { get; }

        // these are mandatory in Contentful, and should never be null for a published scheme
        #region Mandatory in Contentful

        public int? DefaultOrder { get; }

        public int? PopularityOrder { get; }

        public int? DurationOrder { get; }

        public int? CostOrder { get; }

        public string? Name { get; }
        public string? ShortName { get; }
        public string? VisitSchemeInformation { get; }
        public HtmlString? ShortDescription { get; }
        public HtmlString? ShortCost { get; }
        public HtmlString? ShortBenefits { get; }
        public HtmlString? ShortTime { get; }

        public string? ComparisonRecruitOrTrain { get; }
        public string? ComparisonAgeCriteria { get; }
        public string? ComparisonCost { get; }
        public string? ComparisonDuration { get; }

        #endregion Mandatory in Contentful

        // these are option in Contentful, and can be null for a published scheme
        #region Optional in Contentful

        public HtmlString? DetailsPageOverride { get; }
        public HtmlString? Description { get; }
        public IEnumerable<SubScheme> SubSchemes { get; }
        public HtmlString? Cost { get; }
        public HtmlString? Responsibility { get; }
        public HtmlString? Benefits { get; }
        public IEnumerable<CaseStudy> CaseStudies { get; }
        public HtmlString? CaseStudiesPreamble { get; }
        public string? OfferHeader { get; }
        public HtmlString? Offer { get; }
        public HtmlString? AdditionalFooter { get; }

        #endregion Optional in Contentful

        // when we display the matching schemes on the filter page, we'll sort largest to smallest
        public int Size { get; }
        public IEnumerable<string> FilterAspects { get; }
        public string HtmlId { get; }

        public List<InterimPageComponent> Components { get; set; } = new List<InterimPageComponent>();

        public InterimPreamble? InterimPreamble { get; set; }

        public Scheme(
            string? name, 
            string? shortName,
            string? visitSchemeInformation,
            HtmlString? shortDescription, 
            HtmlString? shortCost, 
            HtmlString? shortBenefits, 
            HtmlString? shortTime,
            string? comparisonRecruitOrTrain,
            string? comparisonAgeCriteria,
            string? comparisonCost,
            string? comparisonDuration,
            string url, 
            int size,
            IEnumerable<string> filterAspects,
            IEnumerable<CaseStudy>? caseStudies = null,
            HtmlString? caseStudiesPreamble = null,
            HtmlString? detailsPageOverride = null,
            HtmlString? description = null, 
            HtmlString? cost = null, 
            HtmlString? responsibility = null, 
            HtmlString? benefits = null,
            string? offerHeader = null, 
            HtmlString? offer = null, 
            HtmlString? additionalFooter = null,
            IEnumerable<SubScheme>? subSchemes = null,
            int? defaultOrder = null,
            int? popularityOrder = null,
            int? durationOrder = null,
            int? costOrder = null,
            List<InterimPageComponent>? components = null,
            InterimPreamble? interimPreamble = null
        )
        {
            Name = name;
            ShortName = shortName;
            VisitSchemeInformation = visitSchemeInformation;
            ShortDescription = shortDescription;
            ShortCost = shortCost;
            ShortBenefits = shortBenefits;
            ShortTime = shortTime;
            ComparisonRecruitOrTrain = comparisonRecruitOrTrain;
            ComparisonAgeCriteria = comparisonAgeCriteria;
            ComparisonCost = comparisonCost;
            ComparisonDuration = comparisonDuration;
            Url = url;
            Size = size;
            FilterAspects = filterAspects;
            CaseStudies = caseStudies ?? Enumerable.Empty<CaseStudy>();
            CaseStudiesPreamble = caseStudiesPreamble;
            DetailsPageOverride = detailsPageOverride;
            SubSchemes = subSchemes ?? Enumerable.Empty<SubScheme>();
            Description = description;
            Cost = cost;
            Responsibility = responsibility;
            Benefits = benefits;
            OfferHeader = offerHeader;
            Offer = offer;
            AdditionalFooter = additionalFooter;

            HtmlId = SanitizeHtmlId(url);
            if (HtmlId == "")
                throw new ArgumentException("Must sanitize to a valid HTML id", nameof(url));

            DefaultOrder = defaultOrder;
            PopularityOrder = popularityOrder;
            DurationOrder = durationOrder;
            CostOrder = costOrder;

            Components = components ?? new List<InterimPageComponent>();

            InterimPreamble = interimPreamble;

        }

        private string SanitizeHtmlId(string unsanitizedId)
        {
            //todo: now run online, so we could compile (although not on a fast path)

            // strip invalid chars
            string sanitizedHtmlId = Regex.Replace(unsanitizedId, @"[^a-zA-Z0-9-_:\.]", "");

            // ensure starts with a letter
            return Regex.Replace(sanitizedHtmlId, @"^[^a-zA-Z]*", "");
        }
    }
}
