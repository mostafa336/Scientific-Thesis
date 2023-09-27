using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Thesis.Models;
using Thesis.Repository;

namespace Thesis.Services
{
    public class AdminService :IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository _adminRepository) {
            this._adminRepository = _adminRepository;
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        public int IsCredentialCorrect(Admin admin)
        {
            admin.AdPassword = HashPassword(admin.AdPassword);
            return _adminRepository.DBCheck(admin);
            
        }
        public ClaimsIdentity CreateClaim(Admin Admin)
        {

            int id = IsCredentialCorrect(Admin);

            if (id != 0)
            {
                var claims = new List<Claim>
                   { new Claim(ClaimTypes.Name, Admin.AdEmail),
                     new Claim("Role", "Admin"),
                     new Claim("Id", id.ToString())
                    };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                return claimsIdentity;

                
            }
            return null;
            }
            
            
    }
}
