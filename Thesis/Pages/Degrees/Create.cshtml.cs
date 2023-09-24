using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Thesis.Models;
using Thesis.Services;

namespace Thesis.Pages.Degrees
{
    public class CreateModel : PageModel
    {
        private readonly IDegreeService _iu;

        public CreateModel(IDegreeService _iu)
        {
            this._iu = _iu;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Degree Degree { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!_iu.Insert(Degree))
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
