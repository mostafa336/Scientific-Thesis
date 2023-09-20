using Microsoft.AspNetCore.Mvc;
using Thesis.Models;

namespace Thesis.Repository
{
    public interface IDegreeRepository
    {
        IEnumerable<Degree> GetAll();
        Degree GetById(int DegreeId);
        bool Insert(Degree degree);
        bool Update(Degree degree);
        bool Delete(int DegreeId);
    }
}
