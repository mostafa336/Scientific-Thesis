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
    public class IndexModel : PageModel
    {
        private readonly Thesis.Models.ScienteficThesisDbContext _context;

        public IndexModel(Thesis.Models.ScienteficThesisDbContext context)
        {
            _context = context;
        }

        public IList<Degree> Degree { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Degrees != null)
            {
                Degree = await _context.Degrees.ToListAsync();
            }
        }
    }
}
