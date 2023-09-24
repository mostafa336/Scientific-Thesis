using Thesis.Models;

namespace Thesis.Repository
{
    public interface IUniversityRepository
    {
        IEnumerable<University> GetAll();
        University GetById(int tId);
        bool Insert(University t);
        bool Update(University t);
        bool Delete(int tId);
    }
}
