using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Thesis.Repository;
using Thesis.Models;

namespace Thesis.Models
{
    public class DegreeRepository : IDegreeRepository
    {
        private readonly ScienteficThesisDbContext _context;
        public DegreeRepository() {
            _context = new ScienteficThesisDbContext();
        }
      
        public IEnumerable<Degree> GetAll()
        {
            IEnumerable<Thesis.Models.Degree> Degrees = _context.Degrees;
            return Degrees;
        }

        public Degree? GetById(int degreeId)
        {
            var TDegree = _context.Degrees.Find(degreeId);
            if (TDegree == null)
            {
                return null;
            }
            return TDegree;
        }

        public bool Insert(Degree degree)
        {
            _context.Degrees.Add(degree);
            _context.SaveChanges();
            return true;
        }
        public bool Update(Degree degree)
        {
            var TDegree = _context.Degrees.Find(degree.DegId) ;
            if(TDegree != null)
            {
                TDegree.DegNameAr = degree.DegNameAr;
                TDegree.DegNameEn = degree.DegNameEn;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Delete(int degreeId)
        {
            var TDegree = _context.Degrees.Find(degreeId);
            if (TDegree != null)
            {
                _context.Degrees.Remove(TDegree);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
