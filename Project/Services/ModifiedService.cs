using Microsoft.AspNetCore.Mvc;
using Thesis.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.IO.MemoryMappedFiles;
using static System.Net.Mime.MediaTypeNames;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http; // Import IFormFile
using System.Linq;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Thesis.Pages.Modified;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Thesis.Repository;
using Microsoft.EntityFrameworkCore;

namespace Thesis.Services
{
    public class ModifiedService : IModifiedService
    {
        private readonly IHostingEnvironment _HostEnvironment;
        private readonly IModifiedRepository _IModifiedRepository;

        public ModifiedService(IHostingEnvironment _HostEnvironment, IModifiedRepository _IModifiedRepository)
        {
            this._HostEnvironment = _HostEnvironment;
            this._IModifiedRepository = _IModifiedRepository;
        }

        public IActionResult ViewerNewTab(string fileName, string directory)
        {
            var filePath = Path.Combine(_HostEnvironment.WebRootPath, directory, fileName);
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return new FileContentResult(fileBytes, "application/pdf");
        }

        public IEnumerable<ModifiedApplication> GetAll()
        {
            IEnumerable<ModifiedApplication> data =  _IModifiedRepository.GetAll();

            ModifiedApplication oneOnly = data.FirstOrDefault();

            return data;
        }

        public ModifiedApplication? getById(int id)
        {
            return _IModifiedRepository.getById(id);
        }

        public async  Task<ModifiedApplication> EditAsync(ModifiedApplication ToModify)
        {
            return await _IModifiedRepository.EditAsync(ToModify);
        }

    }
}

