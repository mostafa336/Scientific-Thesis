using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Thesis.Models;

namespace Thesis.Pages.Universties
{
    public class EditModel : PageModel
    {
        private readonly Thesis.Models.ScienteficThesisDbContext _context;

        public EditModel(Thesis.Models.ScienteficThesisDbContext context)
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

            var university =  await _context.Universities.FirstOrDefaultAsync(m => m.UniId == id);
            if (university == null)
            {
                return NotFound();
            }
            University = university;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(University).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityExists(University.UniId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UniversityExists(int id)
        {
          return (_context.Universities?.Any(e => e.UniId == id)).GetValueOrDefault();
        }
    }
}
