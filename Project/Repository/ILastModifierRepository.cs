using Thesis.Models;

namespace Thesis.Repository
{
    public interface ILastModifierRepository
    {
        public IEnumerable<Admin> GetAll();
        
        public Admin GetById(int id);
    }
}
