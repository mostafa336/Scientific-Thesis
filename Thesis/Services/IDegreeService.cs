using Thesis.Models;

namespace Thesis.Services
{
    public interface IDegreeService
    {
        IEnumerable<Degree> GetAll();
        Degree GetById(int? TId);
        bool Insert(Degree t);
        bool Update(Degree t);
        bool Delete(int? TId);
    }
}
