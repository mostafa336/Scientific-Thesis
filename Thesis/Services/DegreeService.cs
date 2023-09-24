using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;
using Thesis.Models;
using Thesis.Repository;

namespace Thesis.Services
{
    public class DegreeService : IDegreeService
    {
        private readonly IDegreeRepository _DegRepo;
        public DegreeService(IDegreeRepository repo)
        {
            _DegRepo = repo;
        }

        public IEnumerable<Degree> GetAll()
        {
            IEnumerable <Degree> Degrees = _DegRepo.GetAll(); //calling interface
            return Degrees;
        }

        public Degree? GetById(int? degreeId)
        {
            if (degreeId == null)
            {
                return null;
            }
            var TDegree = _DegRepo.GetById((int)degreeId);
            return TDegree;
        }
        public bool Insert(Degree degree)
        {
            if(degree == null)
                return false;

            bool result = _DegRepo.Insert(degree);
            return result;
        }
        public bool Update(Degree degree)
        {
            bool result = _DegRepo.Update(degree);
            return result;
        }
        public bool Delete(int? id)
        {
            if (id == null)
            {
                return false;
            }

            bool result = _DegRepo.Delete((int)id);
            return result;
        }


    }
}
