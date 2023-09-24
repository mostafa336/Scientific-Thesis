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
            //_context.FirstApplications.Add(orginal);
            //_context.SaveChanges();
            //DateTime dateTime = orginal.AppSubmissionTime;
            //string id = _context.FirstApplications.FromSqlRaw($"SELECT APP_ID FROM FirstApplication WHERE APP_SubmissionTime ={0};", dateTime).FirstOrDefault();
            //edit.AppId = 
            //_context.ModifiedApplications.Add(edit);
            //return true;
            //--------------------------
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
