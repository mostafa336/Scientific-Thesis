using System.Collections.Generic;
using System.Security.Claims;
using Thesis.Models;

namespace Thesis.Services
{
    public interface IAdminService
    {
        public string HashPassword(string password);
        public int IsCredentialCorrect(Admin admin);
        public ClaimsIdentity CreateClaim(Admin Admin);


    }
}
