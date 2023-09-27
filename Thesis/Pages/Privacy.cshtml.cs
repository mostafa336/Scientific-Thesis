using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Thesis.Services;
using DocumentFormat.OpenXml.Spreadsheet;
using Thesis.Models;

namespace Thesis.Pages
{
    [Authorize(Policy = "RequireAdminRole")]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IExcelGenService excelGenService;

        public PrivacyModel(ILogger<PrivacyModel> logger, IExcelGenService excelGenService)
        {
            _logger = logger;
            this.excelGenService = excelGenService;
        }


        public async Task<IActionResult> OnPostLogout()
        { //for Excelsheet download
            //return File(excelGenService.DownloadSheet(), "application/octet-stream", Path.GetFileName("C:\\Users\\Tamim\\OneDrive - Alexandria University\\Desktop\\BA - Internship'23\\.NET\\Thesis\\wwwroot\\ExcelFactory\\text.xlsx"));
                            //For log out
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToPage("/Login/Create");

        }
    }
}