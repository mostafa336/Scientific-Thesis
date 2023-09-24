using Microsoft.EntityFrameworkCore;
using Thesis.Models;

namespace Thesis.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ScienteficThesisDbContext _context;
        public ApplicationRepository(ScienteficThesisDbContext context)
        {
            _context = context;
        }
        public bool Insert(FirstApplication orginal,ModifiedApplication edit)
        {

            _context.FirstApplications.Add(orginal);
            _context.ModifiedApplications.Add(edit);
            _context.SaveChanges();
            return true;


        }
        public bool Delete(int appId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FirstApplication> GetAll()
        {
            throw new NotImplementedException();
        }

        public FirstApplication GetByIdOrginal(int appId)
        {
            throw new NotImplementedException();
        }

        public bool Update(ModifiedApplication edit)
        {
            throw new NotImplementedException();
        }
    }
}
