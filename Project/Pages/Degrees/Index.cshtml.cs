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
    public class IndexModel : PageModel
    {
        private readonly IDegreeService _iu;

        public IndexModel(IDegreeService _iu)
        {
            this._iu = _iu;
        }

        public IList<Degree> Degree { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_iu.GetAll() != null)
            {
                Degree =  _iu.GetAll().ToList();
            }

        }
    }
}
