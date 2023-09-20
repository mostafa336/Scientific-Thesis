using Microsoft.AspNetCore.Mvc;
using ScienteficThesis.Models;

namespace ScienteficThesis.Repository
{
    public class UniRepository : IUni
    {
        private readonly ScienteficThesisDbContext _context;
        public UniRepository() {
            _context = new ScienteficThesisDbContext();
        
        }

        void IUni.create(University u)
        {
            _context.Universities.Add(u);
            _context.SaveChanges();
        }

        IEnumerable<University> IUni.getAll()
        {
            throw new NotImplementedException();
        }

        University IUni.getById(int id)
        {
            throw new NotImplementedException();
        }

        void IUni.update(University u)
        {
            throw new NotImplementedException();
        }

        void IUni.delete(int id)
        {
            var u = _context.Universities.Find(id);
            if (u != null)
            {
                _context.Remove(u);
            }
        }
    }
}
