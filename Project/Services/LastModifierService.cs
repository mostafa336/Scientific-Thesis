using Microsoft.EntityFrameworkCore;
using Thesis.Models;
using Thesis.Repository;

namespace Thesis.Services
{
    
    public class LastModifierService : ILastModifierService
    {
        private readonly ILastModifierRepository _ILastModifierRepository;
        public LastModifierService(ILastModifierRepository _ILastModifierRepository)
        {
            this._ILastModifierRepository = _ILastModifierRepository;
        }
        public IEnumerable<Admin> GetAll()
        {
           return _ILastModifierRepository.GetAll();
        }
        public Admin GetById(int id)
        {
            return _ILastModifierRepository.GetById(id);
        }

    }
}
