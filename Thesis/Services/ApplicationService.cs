using System.Collections.Generic;
using Thesis.Models;
using Thesis.Repository;
using System.Text.Json;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.Extensions.Hosting.Internal;

namespace Thesis.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IHostingEnvironment _HostEnvironment;

        public ApplicationService(IApplicationRepository _applicationRepository, IHostingEnvironment _HostEnvironment)
        {
            this._applicationRepository = _applicationRepository;
            this._HostEnvironment = _HostEnvironment;
        }
        public bool Insert(FirstApplication application)
        {
            application.AppSubmissionTime = DateTime.Now;
            ModifiedApplication m = new ModifiedApplication();
            m.AppNameAr = application.AppNameAr;
            m.AppNameEn = application.AppNameEn;
            m.AppBirthDate = application.AppBirthDate;
            m.AppEmail = application.AppEmail;
            m.AppJob = application.AppJob;
            m.AppNationalId = application.AppNationalId;
            m.AppNationalityId = application.AppNationalityId;
            m.AppThesisTitleAr = application.AppThesisTitleAr;
            m.AppThesisTitleEn = application.AppThesisTitleEn;
            m.AppVolumes = application.AppVolumes;
            m.AppPages  = application.AppPages;
            m.AppPublicationYear = application.AppPublicationYear;  
            m.AppDepartment = application.AppDepartment;
            m.AppFaculty  = application.AppFaculty;
            m.AppUniversityId   = application.AppUniversityId;
            m.AppKeyword    = application.AppKeyword;
            m.AppNotes = application.AppNotes;
            m.AppSubmissionLetter = application.AppSubmissionLetter;
            m.AppThesis = application.AppThesis;
            m.AppLastModificationDate = application.AppSubmissionTime;
            m.AppLanguageMaster = application.AppLanguageMaster;
            m.AppDegreeId = application.AppDegreeId;
            m.AppStatusId = 1;




            _applicationRepository.Insert(application,m);


            return true;

            
        }

        public async Task<String> UploadThesisAsync(IFormFile File,String directory)
        {
            String f = "-";
            if (File != null && File.Length > 0)
            {
                 f = DateTime.Now.ToString("yyyyMMddHHmmssffff");

                string fileName =   f + Path.GetExtension(File.FileName); // name conc + Extension
                string filePath = Path.Combine(_HostEnvironment.WebRootPath, directory, fileName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await File.CopyToAsync(fileStream);
                   // fileStream.Flush();
                }
                
            }
            return f;


        }
    }
}
