using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Thesis.Models;
using System.Web.Mvc;
using System.Net.Security;

namespace Thesis.Pages.Login
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Thesis.Models.ScienteficThesisDbContext _context;

        public IndexModel(Thesis.Models.ScienteficThesisDbContext context)
        {
            _context = context;
        }

        public IList<Admin> Admin { get;set; } = default!;
        public String name { get; set; } = default! ;

        public async Task OnGetAsync()
        {
            if (_context.Admins != null)
            {
                Admin = await _context.Admins.ToListAsync();

            }
            var userIdClaim = User.FindFirst("Id");

            if (userIdClaim != null)
            {
                name = userIdClaim.Value;
            }
        }
    }
}
