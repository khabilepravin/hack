using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BLHackWeb.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly List<SubscriptionItem> _data = null;
        public SubscriptionsController()
        {
            _data = new List<SubscriptionItem>();
            _data.Add(new SubscriptionItem { Id = "1", Name = "Personal Injury", CommentaryFileName = "FULL COMMENTARY - PERSONAL INJURY (NSW).pdf" });
            _data.Add(new SubscriptionItem { Id = "2", Name = "Mortgages", CommentaryFileName = "" });
        }

        public IActionResult Index(string id)
        {
            return View("Index", id);
        }
    }


    public class SubscriptionItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CommentaryFileName { get; set; }
    }
}