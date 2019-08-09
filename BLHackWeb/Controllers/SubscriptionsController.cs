using Microsoft.AspNetCore.Mvc;

namespace ByLawyersHackWeb.Controllers
{
    public class SubscriptionsController : Controller
    {
        public IActionResult Index(string id)
        {
            return View("Index", id);
        }
    }
}