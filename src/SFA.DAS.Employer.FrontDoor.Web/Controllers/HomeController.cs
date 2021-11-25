﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SFA.DAS.Employer.FrontDoor.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SFA.DAS.Employer.FrontDoor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static readonly HomeModel HomeModel = new HomeModel();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int aaa = 1;
            int bbb = 0;
            int ccc = aaa / bbb;
            return View(ccc.ToString(), HomeModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel(Activity.Current?.Id ?? HttpContext.TraceIdentifier ));
        }

        public IActionResult Cookies()
        {
            return View(HomeModel);
        }

        public IActionResult AccessibilityStatement()
        {
            return View(HomeModel);
        }
    }
}
