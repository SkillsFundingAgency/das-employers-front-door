﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SFA.DAS.Employer.FrontDoor.Web.Models;
using System.Diagnostics;

namespace SFA.DAS.Employer.FrontDoor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel(Activity.Current?.Id ?? HttpContext.TraceIdentifier ));
        }

        public IActionResult Cookies()
        {
            return View();
        }

        public IActionResult AccessibilityStatement()
        {
            return View();
        }
    }
}
