﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SFA.DAS.FindEmploymentSchemes.Contentful.Model.Content.Interfaces;
using SFA.DAS.FindEmploymentSchemes.Contentful.Services.Interfaces;
using SFA.DAS.FindEmploymentSchemes.Web.Models;
using SFA.DAS.FindEmploymentSchemes.Web.Services.Interfaces;

namespace SFA.DAS.FindEmploymentSchemes.Web.Services
{
    public class SchemesModelService : ISchemesModelService
    {
        private const string HomepagePreambleUrl = "home";

        private readonly IContentService _contentService;

#pragma warning disable CS8618
        public SchemesModelService(IContentService contentService)
        {
            _contentService = contentService;
            contentService.ContentUpdated += OnContentUpdated;

            BuildModels();
        }
#pragma warning restore CS8618

        // tried https://github.com/manuelroemer/Nullable (as we're using a legacy lts release, but didn't work)
        //[MemberNotNull(nameof(HomeModel))]
        //[MemberNotNull(nameof(SchemeDetailsModels))]
        private void BuildModels()
        {
            HomeModel = CreateHomeModel(_contentService.Content);
            SchemeDetailsModels = BuildSchemeDetailsModelsDictionary();
        }

        private void OnContentUpdated(object? sender, EventArgs args)
        {
            BuildModels();
        }

        public HomeModel HomeModel { get; private set; }

        public HomeModel CreateHomeModel(IContent content)
        {
            return new HomeModel(
                content.Pages.First(p => p.Url == HomepagePreambleUrl).Content,
                content.Schemes,
                new[] { content.MotivationsFilter, content.SchemeLengthFilter, content.PayFilter });
        }

        private IReadOnlyDictionary<string, SchemeDetailsModel> SchemeDetailsModels { get; set; }

        private ReadOnlyDictionary<string, SchemeDetailsModel> BuildSchemeDetailsModelsDictionary()
        {
            var schemeDetailsModels = new Dictionary<string, SchemeDetailsModel>();

            foreach (string schemeUrl in _contentService.Content.Schemes.Select(s => s.Url))
            {
                schemeDetailsModels.Add(schemeUrl, new SchemeDetailsModel(schemeUrl, _contentService.Content.Schemes));
            }

            return new ReadOnlyDictionary<string, SchemeDetailsModel>(schemeDetailsModels);
        }

        public SchemeDetailsModel? GetSchemeDetailsModel(string schemeUrl)
        {
            SchemeDetailsModels.TryGetValue(schemeUrl, out SchemeDetailsModel? schemeDetailsModel);
            return schemeDetailsModel;
        }
    }
}
