using Microsoft.AspNetCore.Mvc;
using ScienteficThesis.Models;
using ScienteficThesis.Repository;
using ScienteficThesis.Services;
using System.Diagnostics;

namespace ScienteficThesis.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  IUni iu;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Privacy(string NameEn, string NameAr)
        {
            University u = new University()
            {
                UniNameAr = NameAr,
                UniNameEn  = NameEn

            };

            iu = new UniRepository();
            UniValidationService uv = new UniValidationService(iu);
            uv.setModel(u);
            if(uv.ValidUni())
            {
                ViewBag.En = "Data Submitted Successfuly into the database";
            }
            else
            {
                ViewBag.En = "Data insertion Proccess failed into the database";
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}