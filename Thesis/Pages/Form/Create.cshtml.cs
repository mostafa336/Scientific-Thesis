using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using Thesis.Models;
using Thesis.Services;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Thesis.Pages.Form
{
    public class CreateModel : PageModel
    {
        private readonly IApplicationService _IAppService;
        private readonly IDegreeService _degreeService;
        private readonly ICountryService _countryService;
//        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(IApplicationService _IAppService, IDegreeService _degreeService,ICountryService _countryService)
        {
            this._IAppService = _IAppService;
            this._degreeService = _degreeService;
            this._countryService = _countryService;
           // this._webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {

        ViewData["AppDegreeId"] = new SelectList(_degreeService.GetAll(), "DegId", "DegNameEn");
        ViewData["AppNationalityId"] = new SelectList(_countryService.GetAll(), "CntId", "CntNameEn");
        //ViewData["AppUniversityId"] = new SelectList(_context.Universities//, "UniId", "UniNameEn");
            return Page();
        }

        [BindProperty]
        public FirstApplication FirstApplication { get; set; } = default!;

        [BindProperty]
        public IFormFile File { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()//Done
        {


            if(_IAppService != null)
            {
                _IAppService.UploadThesis(File);
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
