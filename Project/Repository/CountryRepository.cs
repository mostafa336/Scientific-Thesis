using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Thesis.Repository;
using Thesis.Models;
using Thesis.Services;

namespace Thesis.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ScienteficThesisDbContext _context;
        public CountryRepository()
        {
            _context = new ScienteficThesisDbContext();
        }
        public bool Delete(int tId)
        {
            Country TCountry = _context.Countries.Find(tId);
            if (TCountry != null)
            {
                _context.Countries.Remove(TCountry);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Country> GetAll()
        {
            IEnumerable<Country> Countries = _context.Countries;
            return Countries;
        }

        public Country? GetById(int tId)
        {
            var tmp = _context.Countries.FirstOrDefault(country => country.CntId == tId);
            if (tmp == null)
                return null;
            return tmp;
        }

        public bool Insert(Country t)
        {
            throw new NotImplementedException();
        }

        public bool Update(Country t)
        {
            throw new NotImplementedException();
        }
    }
}
