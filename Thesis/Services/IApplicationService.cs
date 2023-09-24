using Microsoft.AspNetCore.Mvc;
using Thesis.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Thesis.Services
{
    public interface IApplicationService
    {
        public bool Insert(FirstApplication application);
        public bool UploadThesis(IFormFile File); 

    }
}
