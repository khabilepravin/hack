using BLHackWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Linq;

namespace BLHackWeb.Controllers
{
    public class CommentaryController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public CommentaryController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult TableOfContents(string id)
        {
            var provider = new PhysicalFileProvider(_hostingEnvironment.ContentRootPath);

            var contentItem = (from c in DataSource.subscriptionItems
                               where c.Id == id
                               select c).FirstOrDefault<SubscriptionItem>();

            var fileInfo = provider.GetFileInfo($"wwwroot/{contentItem.CommentaryFileName}");

            var stream = fileInfo.CreateReadStream();

            var contents =  PdfLib.PdfIndexParser.GetContentPagesText(stream, 2);

           var tableOfContents = PdfLib.PdfIndexParser.GetTableOfContents(contents);

            return View(tableOfContents);
        }
    }
}