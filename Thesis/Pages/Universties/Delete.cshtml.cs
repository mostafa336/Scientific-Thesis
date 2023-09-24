using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Thesis.Models;

namespace Thesis.Pages.Universties
{
    public class DeleteModel : PageModel
    {
        private readonly Thesis.Models.ScienteficThesisDbContext _context;

        public DeleteModel(Thesis.Models.ScienteficThesisDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public University University { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Universities == null)
            {
                return NotFound();
            }

            var university = await _context.Universities.FirstOrDefaultAsync(m => m.UniId == id);

            if (university == null)
            {
                return NotFound();
            }
            else 
            {
                University = university;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Universities == null)
            {
                return NotFound();
            }
            var university = await _context.Universities.FindAsync(id);

            if (university != null)
            {
                University = university;
                _context.Universities.Remove(University);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
