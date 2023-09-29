using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thesis.Models;

namespace Thesis.Repository
{
    public interface IModifiedRepository
    {
        public IEnumerable<ModifiedApplication> GetAll();
        public ModifiedApplication? getById(int id);
        Task<ModifiedApplication> EditAsync(ModifiedApplication ToModify);
    }
}
