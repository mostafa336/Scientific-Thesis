using Thesis.Models;

namespace Thesis.Repository
{
    public class LastModifierRepository : ILastModifierRepository
    { 
        private readonly ScienteficThesisDbContext _context;
        
        public LastModifierRepository(ScienteficThesisDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Admin> GetAll()
        {
            return _context.Admins;
        }

        public Admin? GetById(int id)
        {
            var tmp = _context.Admins.FirstOrDefault(Admin => Admin.AdId == id);
            if (tmp == null)
                return null;
            return tmp; 
        }
    }
}
