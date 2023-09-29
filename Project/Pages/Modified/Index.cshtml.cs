using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Thesis.Models;
using Thesis.Services;

namespace Thesis.Pages.Modified
{
    public class IndexModel : PageModel
    {
        private readonly IModifiedService _modifiedService;

        public IndexModel(Thesis.Models.ScienteficThesisDbContext context,IModifiedService modifiedService)
        {
            _modifiedService = modifiedService;
        }

        public IList<ModifiedApplication> ModifiedApplication { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if(_modifiedService.GetAll() != null)
            {
                ModifiedApplication = _modifiedService.GetAll().ToList();
            }   
        }
        
    }
}
