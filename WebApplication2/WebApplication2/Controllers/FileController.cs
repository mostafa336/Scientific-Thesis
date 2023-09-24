using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http; // Import IFormFile
using System.IO; // Import System.IO for Directory and Path
using System.Linq;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WebApplication2.Controllers
{
    public class FileController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Index(string fileName = "")
        {
            FileClass fileObj = new FileClass();
            fileObj.Name = fileName;

            string path = Path.Combine(_hostingEnvironment.WebRootPath, "files");

            int nId = 1;
            foreach (string pdfpath in Directory.EnumerateFiles(path, "*.pdf"))
            {
                fileObj.Files.Add(new FileClass
                {
                    FileId = nId++,
                    Name = Path.GetFileName(pdfpath),
                    Path = pdfpath
                });
            }
            return View(fileObj);
        }

        [HttpPost]
        public IActionResult Index(IFormFile file, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            if (file != null && file.Length > 0)
            {
                string fileName = Path.Combine(hostingEnvironment.WebRootPath, "files", file.FileName);
                using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
            // Redirect to the GET action to refresh the page
            return RedirectToAction("Index");
        }

        public IActionResult PDFViewerNewTab(string fileName)
        {
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "files", fileName);
            return File(System.IO.File.ReadAllBytes(path), "application/pdf");
        }
    }
}
