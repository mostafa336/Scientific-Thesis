using Thesis.Models;

namespace Thesis.Repository
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly ScienteficThesisDbContext _context;
        public UniversityRepository()
        {
            _context = new ScienteficThesisDbContext();
        }
        public bool Delete(int tId)
        {
            var TUnis = _context.Universities.Find(tId);
            if (TUnis != null)
            {
                _context.Universities.Remove(TUnis);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<University> GetAll()
        {
            IEnumerable<University> Unis = _context.Universities;
            return Unis;
        }

        public University? GetById(int tId)
        {
            var tmp = _context.Universities.FirstOrDefault(University => University.UniId == tId);
            if (tmp == null)
                return null;
            return tmp;
        }

        public bool Insert(University t)
        {
            throw new NotImplementedException();
        }

        public bool Update(University t)
        {
            throw new NotImplementedException();
        }
    }
}
