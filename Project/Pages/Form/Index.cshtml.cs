using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Thesis.Models;

namespace Thesis.Pages.Form
{
    public class IndexModel : PageModel
    {
        private readonly Thesis.Models.ScienteficThesisDbContext _context;

        public IndexModel(Thesis.Models.ScienteficThesisDbContext context)
        {
            _context = context;
        }

        public IList<FirstApplication> FirstApplication { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FirstApplications != null)
            {
                FirstApplication = await _context.FirstApplications
                .Include(f => f.AppDegree)
                .Include(f => f.AppNationality)
                .Include(f => f.AppUniversity).ToListAsync();
            }
        }
    }
}
