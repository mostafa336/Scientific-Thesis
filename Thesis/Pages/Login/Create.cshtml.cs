using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Thesis.Services;
using Thesis.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Thesis.Pages.Login
{
    public class CreateModel : PageModel
    {
        private readonly Thesis.Models.ScienteficThesisDbContext _context;
        private readonly IAdminService _iadminservice;

        public CreateModel(Thesis.Models.ScienteficThesisDbContext context, IAdminService _iadminservice)
        {
            _context = context;
            this._iadminservice = _iadminservice;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Admin Admin { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            ClaimsIdentity claims = _iadminservice.CreateClaim(Admin);

            if (claims != null )
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claims));
                return RedirectToPage("/Index");
            }

                return Page();

        }
        

        }
    }

