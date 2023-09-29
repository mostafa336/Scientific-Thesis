using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thesis.Models;


namespace Thesis.Repository
{
    public class ModifiedRepository : IModifiedRepository
    {
        private readonly Thesis.Models.ScienteficThesisDbContext _context;
        public ModifiedRepository(Thesis.Models.ScienteficThesisDbContext _context) { 
             this._context = _context;
        }

        public async Task<ModifiedApplication> EditAsync(ModifiedApplication ToModify)
        {
            _context.Attach(ToModify).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return ToModify;
        }

        
        public IEnumerable<ModifiedApplication> GetAll()
        {
            return _context.ModifiedApplications
                .Include(m=>m.AppDegree)
                .Include(m => m.AppLastModifier)
                .Include(m => m.AppNationality)
                .Include(m => m.AppStatus)
                .Include(m => m.AppUniversity);
            
        }
    public ModifiedApplication? getById(int id)
        {
            var modifiedApplication = _context.ModifiedApplications.FirstOrDefault(m => m.AppId == id);
            if (modifiedApplication != null)
            {
                   return modifiedApplication;
            }  
            return null;
        }


        
    }
}
