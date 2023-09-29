using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Thesis.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Thesis.Repository;
using Microsoft.EntityFrameworkCore;

namespace Thesis.Services
{
    public interface IModifiedService
    {
        public IEnumerable<ModifiedApplication> GetAll();
        public ModifiedApplication? getById(int id);
        Task<ModifiedApplication> EditAsync(ModifiedApplication ToModify);
        public IActionResult ViewerNewTab(string fileName,string directory);

    }
}
