using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BLHackWeb.Models;
using BLHackWeb.Controllers;

namespace BLHackWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly List<SubscriptionItem> _data = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            _data = new List<SubscriptionItem>();
            _data.Add(new SubscriptionItem { Id = "1", Name = "Personal Injury", CommentaryFileName = "FULL COMMENTARY - PERSONAL INJURY (NSW).pdf" });
            _data.Add(new SubscriptionItem { Id = "2", Name = "Mortgages", CommentaryFileName = "" });
        }

        public IActionResult Index()
        {
            return View(_data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
