using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;
using Thesis.Models;
using Thesis.Repository;

namespace Thesis.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _CNT;
        public CountryService(ICountryRepository _CNT)
        {
            this._CNT = _CNT;
        }

        public IEnumerable<Country> GetAll()
        {
            IEnumerable<Country> Countries = _CNT.GetAll(); //calling interface
            return Countries;
        }

        public Country? GetById(int? CountryId)
        {
            if (CountryId == null)
            {
                return null;
            }
            var TCountry = _CNT.GetById((int)CountryId);
            return TCountry;
        }
        public bool Insert(Country c)
        {
            if (c == null)
                return false;

            bool result = _CNT.Insert(c);
            return result;
        }
        public bool Update(Country c)
        {
            bool result = _CNT.Update(c);
            return result;
        }
        public bool Delete(int? id)
        {
            if (id == null)
            {
                return false;
            }

            bool result = _CNT.Delete((int)id);
            return result;
        }

        public bool Delete(Country? TId)
        {
            throw new NotImplementedException();
        }
    }
}
