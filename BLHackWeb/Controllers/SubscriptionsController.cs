using BLHackWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BLHackWeb.Controllers
{
    public class SubscriptionsController : Controller
    {
        public IActionResult Index(string id)
        {
            var item = (from d in DataSource.subscriptionItems
            where d.Id == id
            select d).FirstOrDefault<SubscriptionItem>();

            return View("Index", item);
        }
    }
}