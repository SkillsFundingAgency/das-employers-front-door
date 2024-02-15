﻿using Microsoft.AspNetCore.Mvc;
using SFA.DAS.FindEmploymentSchemes.Web.Services.Interfaces;

namespace SFA.DAS.FindEmploymentSchemes.Web.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {

            _contactService = contactService;

        }

        [Route("index")]
        [ResponseCache(Duration = 60 * 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Index()
        {

            ViewData["Title"] = "Find training and employment schemes for your business - Contacts";

            return View(_contactService.GetContactPageModel());

        }

    }

}
