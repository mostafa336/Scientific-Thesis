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
    public class DetailsModel : PageModel
    {
        private readonly IDegreeService _iu;

        public DetailsModel(IDegreeService _iu)
        {
            this._iu = _iu;
        }

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
    }
}
