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

namespace Thesis.Pages.Degrees
{
    public class EditModel : PageModel
    {
        private readonly IDegreeService _iu;

        public EditModel(IDegreeService _iu)
        {
            this._iu = _iu;
        }

        [BindProperty]
        public Degree Degree { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (_iu.GetById(id) == null)
            {
                return NotFound();
            }
            Degree = _iu.GetById(id);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!_iu.Update(Degree))
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }
            
     
        }

    }