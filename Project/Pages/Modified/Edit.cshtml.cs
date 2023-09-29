using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Thesis.Models;
using Thesis.Services;

namespace Thesis.Pages.Modified
{
    public class EditModel : PageModel
    {
        private readonly IModifiedService _IModifiedService;
        private readonly IDegreeService _IDegreeService;
        private readonly ICountryService _ICountryService;
        private readonly IUniversityService _IUniversityService;
        private readonly IStatusService _IStatusService;
        private readonly ILastModifierService _ILastModifierervice;

        public EditModel(IModifiedService _IService,IUniversityService _universityService, IDegreeService _degreeService, ICountryService _countryService, IStatusService statusService, ILastModifierService iLastModifierervice)
        {
            this._IDegreeService = _degreeService;
            this._ICountryService = _countryService;
            this._IUniversityService = _universityService;
            this._IModifiedService = _IService;
            this._IStatusService = statusService;
            this._ILastModifierervice = iLastModifierervice;
        }

        [BindProperty]
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
            ModifiedApplication = modifiedapplication;
            ViewData["AppDegreeId"] = new SelectList(_IDegreeService.GetAll(), "DegId", "DegNameAr");
            ViewData["AppNationalityId"] = new SelectList(_ICountryService.GetAll(), "CntId", "CntNameEn");
            ViewData["AppUniversityId"] = new SelectList(_IUniversityService.GetAll(), "UniId", "UniNameEn");
            ViewData["AppStatusId"] = new SelectList(_IStatusService.GetAll(), "StId", "StState");
            ViewData["AppLastModifierId"] = new SelectList(_ILastModifierervice.GetAll(), "AdId", "AdName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
          
            
            await _IModifiedService.EditAsync(ModifiedApplication);

            return RedirectToPage("./Details", new { id = ModifiedApplication.AppId });
        }

        
    }
}
