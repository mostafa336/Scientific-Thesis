using Thesis.Models;

namespace Thesis.Services
{
    public interface ILastModifierService
    {
        public IEnumerable<Admin> GetAll();
        public Admin GetById(int id);

    }
}
