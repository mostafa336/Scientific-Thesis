using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Thesis.Repository;
using Thesis.Models;
using Thesis.Services;

namespace Thesis.Repository

{
    public class DegreeRepository : IDegreeRepository
    {
        private readonly ScienteficThesisDbContext _context;
        public DegreeRepository()
        {
            _context = new ScienteficThesisDbContext();
        }
        public bool Delete(int tId)
        {
            var TDegree = _context.Degrees.Find(tId);
            if (TDegree != null)
            {
                _context.Degrees.Remove(TDegree);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Degree> GetAll()
        {
            IEnumerable<Degree> Degrees = _context.Degrees;
            return Degrees;
        }

        public Degree? GetById(int Id)
        {
            var tmp = _context.Degrees.FirstOrDefault(degree => degree.DegId == Id);
            if (tmp == null)
                return null;
            return tmp;
        }

        public bool Insert(Degree t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Degree t)
        {
            throw new NotImplementedException();
        }
    }
}
