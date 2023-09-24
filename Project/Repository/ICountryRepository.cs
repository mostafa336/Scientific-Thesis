using Thesis.Models;

namespace Thesis.Repository
{
    public interface ICountryRepository
    {

            IEnumerable<Country> GetAll();
            Country GetById(int tId);
            bool Insert(Country t);
            bool Update(Country t);
            bool Delete(int tId);

    }
}
