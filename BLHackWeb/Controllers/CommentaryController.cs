using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace ByLawyersHackWeb.Controllers
{
    public class CommentaryController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public CommentaryController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult TableOfContents()
        {
            var provider = new PhysicalFileProvider(_hostingEnvironment.ContentRootPath);
           
            var fileInfo = provider.GetFileInfo("wwwroot/FULL COMMENTARY - PERSONAL INJURY (NSW).pdf");

            var stream = fileInfo.CreateReadStream();

            var contents =  PdfLib.PdfIndexParser.GetContentPagesText(stream, 2);

           var tableOfContents = PdfLib.PdfIndexParser.GetTableOfContents(contents);

            return View(tableOfContents);
        }
    }
}