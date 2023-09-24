using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Thesis.Models;
using Thesis.Services;

namespace Thesis.Pages.Degrees
{
    public class DeleteModel : PageModel
    {
        private readonly IDegreeService _iu;

        public DeleteModel(IDegreeService _iu)
        {
            this._iu = _iu;
        }

        [BindProperty]
        public Degree Degree { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (_iu.GetById(id) == null)
            {
                return NotFound();
            }
            Degree = _iu.GetById(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (_iu.Delete(id))
            {
                return RedirectToPage("./Index");

            }
            else
            {
                return Page();
            }
        }
    }
}
