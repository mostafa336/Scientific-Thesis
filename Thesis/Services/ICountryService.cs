using Thesis.Models;

namespace Thesis.Services
{
    public interface ICountryService
    {
        IEnumerable<Country> GetAll();
        Country GetById(int? TId);
        bool Insert(Country t);
        bool Update(Country t);
        bool Delete(int? TId);
    }
}
