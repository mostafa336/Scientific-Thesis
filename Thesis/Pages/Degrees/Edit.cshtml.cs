﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Thesis.Models;

namespace Thesis.Pages.Degrees
{
    public class EditModel : PageModel
    {
        private readonly Thesis.Models.ScienteficThesisDbContext _context;

        public EditModel(Thesis.Models.ScienteficThesisDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Degree Degree { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Degrees == null)
            {
                return NotFound();
            }

            var degree =  await _context.Degrees.FirstOrDefaultAsync(m => m.DegId == id);
            if (degree == null)
            {
                return NotFound();
            }
            Degree = degree;
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

            _context.Attach(Degree).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DegreeExists(Degree.DegId))
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

        private bool DegreeExists(int id)
        {
          return (_context.Degrees?.Any(e => e.DegId == id)).GetValueOrDefault();
        }
    }
}
