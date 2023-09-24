using Microsoft.AspNetCore.Mvc;
using Thesis.Models;

namespace Thesis.Repository
{
    public interface IDegreeRepository
    {
        IEnumerable<Degree> GetAll();
        Degree GetById(int tId);
        bool Insert(Degree t);
        bool Update(Degree t);
        bool Delete(int tId);
    }
}
