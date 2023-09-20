using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Thesis.Models;

namespace Thesis.Pages.Degrees
{
    public class DetailsModel : PageModel
    {
        private readonly Thesis.Models.ScienteficThesisDbContext _context;

        public DetailsModel(Thesis.Models.ScienteficThesisDbContext context)
        {
            _context = context;
        }

      public Degree Degree { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Degrees == null)
            {
                return NotFound();
            }

            var degree = await _context.Degrees.FirstOrDefaultAsync(m => m.DegId == id);
            if (degree == null)
            {
                return NotFound();
            }
            else 
            {
                Degree = degree;
            }
            return Page();
        }
    }
}
