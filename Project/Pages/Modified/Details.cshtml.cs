using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Thesis.Models;
using Thesis.Services;
using System.Collections.Generic;
using Thesis.Repository;
using System.Text.Json;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
namespace Thesis.Pages.Modified
{

    public class DetailsModel : PageModel
    {
        private readonly IModifiedService _IModifiedService;
        private readonly IDegreeService _IDegreeService;
        private readonly ICountryService _ICountryService;
        private readonly IUniversityService _IUniversityService;
        private readonly IStatusService _IStatusService;
        private readonly ILastModifierService _ILastModifierervice;

        public DetailsModel(IModifiedService _IService, IUniversityService _universityService, IDegreeService _degreeService, ICountryService _countryService, IStatusService statusService, ILastModifierService iLastModifierervice)
        {
            this._IModifiedService = _IService;
            this._IDegreeService = _degreeService;
            this._ICountryService = _countryService;
            this._IUniversityService = _universityService;
            this._IStatusService = statusService;
            this._ILastModifierervice = iLastModifierervice;
        }

        

        public ModifiedApplication ModifiedApplication { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modifiedapplication = _IModifiedService.getById((int)id);
            if (modifiedapplication == null)
            {
                return NotFound();
            }
            else
            {
                ModifiedApplication = modifiedapplication;
            }
            var degree = _IDegreeService.GetById(ModifiedApplication.AppDegreeId);
            ViewData["AppDegreeId"] = degree?.DegNameEn;

            var country = _ICountryService.GetById(ModifiedApplication.AppNationalityId);
              ViewData["AppNationalityId"] = country?.CntNameEn;
             
            var university = _IUniversityService.GetById(ModifiedApplication.AppUniversityId);
            ViewData["AppUniversityId"] = university.UniNameEn;

            var status = _IStatusService.GetById(ModifiedApplication.AppStatusId);
            ViewData["AppStatusId"] =status.StState;

            if (ModifiedApplication.AppLastModifierId != null)
            {
                int Lid = (int)ModifiedApplication.AppLastModifierId;
                var admin = _ILastModifierervice.GetById(Lid);
                ViewData["AppLastModifierId"] = admin?.AdName;
            }

            return Page();
        }


        //To Download files:
        public IActionResult OnGetThesisViewer(string filename = "")
        {

            filename += ".pdf";
            return _IModifiedService.ViewerNewTab(filename,"Thesis");
        }

        public IActionResult OnGetSubmissionLetter(string filename = "")
        {
            filename += ".pdf";
            return _IModifiedService.ViewerNewTab(filename,"SubmissionLetter");
        }
     
    }
}
