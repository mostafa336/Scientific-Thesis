using Thesis.Models;

namespace Thesis.Services
{
    public interface IUniversityService
    {
        IEnumerable<University> GetAll();
        University GetById(int? TId);
        bool Insert(University t);
        bool Update(University t);
        bool Delete(int? TId);
    }
}
