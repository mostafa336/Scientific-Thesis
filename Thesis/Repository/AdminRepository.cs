using Microsoft.EntityFrameworkCore;
using Thesis.Models;

namespace Thesis.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ScienteficThesisDbContext _context;
        public AdminRepository()
        {
            _context = new ScienteficThesisDbContext();
        }
        public int DBCheck(Admin admin)
        {
            var cred = _context.Admins.Where(Admin => Admin.AdEmail == admin.AdEmail)
         .Where(Admin => Admin.AdPassword == admin.AdPassword)
         .FirstOrDefault();
            if (cred == null) {
                return 0;
            }
            else
            {
                return cred.AdId;

            }
        }
    }
}
