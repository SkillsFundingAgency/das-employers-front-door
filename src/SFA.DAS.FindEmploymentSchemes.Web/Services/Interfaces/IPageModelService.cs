﻿using Microsoft.AspNetCore.Html;
using System.Collections.Generic;
using SFA.DAS.FindEmploymentSchemes.Contentful.Model.Content;

namespace SFA.DAS.FindEmploymentSchemes.Web.Services.Interfaces
{
    public interface IPageModelService
    {
        IEnumerable<HtmlString> GetErrors(Page page);
    }
}