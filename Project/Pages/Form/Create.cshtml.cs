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
        private readonly IUniversityService _universityService;

        public CreateModel(IUniversityService _universityService,IApplicationService _IAppService, IDegreeService _degreeService,ICountryService _countryService)
        {
            this._IAppService = _IAppService;
            this._degreeService = _degreeService;
            this._countryService = _countryService;
            this._universityService = _universityService;
        }

        public IActionResult OnGet()
        {

        ViewData["AppDegreeId"] = new SelectList(_degreeService.GetAll(), "DegId", "DegNameAr");
        ViewData["AppNationalityId"] = new SelectList(_countryService.GetAll(), "CntId", "CntNameEn");
        ViewData["AppUniversityId"] = new SelectList(_universityService.GetAll(), "UniId", "UniNameEn");
            return Page();
        }

        [BindProperty]
        public FirstApplication FirstApplication { get; set; } = default!;

        [BindProperty]
        public IFormFile ThesisFile { get; set; }
        [BindProperty]
        public IFormFile SubmissionFile { get; set; }
        


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()//Done
        {


            if(_IAppService != null)
            {
                
                 FirstApplication.AppThesis = await _IAppService.UploadThesisAsync(ThesisFile, "Thesis");
                 FirstApplication.AppSubmissionLetter = await _IAppService.UploadThesisAsync(SubmissionFile, "SubmissionLetter");



                _IAppService.Insert(FirstApplication);
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
