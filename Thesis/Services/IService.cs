using Thesis.Models;

namespace Thesis.Services
{
    public interface IService
    {
        IEnumerable<Degree> GetAll();
        Degree GetById(int? DegreeId);
        bool Insert(Degree degree);
        bool Update(Degree degree);
        bool Delete(int? DegreeId);
    }
}
