using Microsoft.AspNetCore.Mvc;

namespace ByLawyersHackWeb.Controllers
{
    public class CommentaryController : Controller
    {
        public IActionResult TableOfContents()
        {
            var contents =  PdfLib.PdfIndexParser.GetContentPagesText(@"..\FULL COMMENTARY - PERSONAL INJURY (NSW).pdf", 2);

            return View();
        }
    }
}