using Thesis.Models;

namespace Thesis.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ScienteficThesisDbContext _context;
        
        public StatusRepository(ScienteficThesisDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Status> GetAll()
        {
            return _context.Statuses;
        }
        public Status? GetById(int id)
        {
            var tmp= _context.Statuses.FirstOrDefault(status => status.StId == id);
            if(tmp == null)
                return null;
            return tmp;
        }

    }
}
