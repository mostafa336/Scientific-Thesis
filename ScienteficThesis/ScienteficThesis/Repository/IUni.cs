using Microsoft.AspNetCore.Mvc;
using ScienteficThesis.Models;

namespace ScienteficThesis.Repository
{
    public interface IUni 
    {
        public University getById(int id);
        public void create(University u);
        public IEnumerable<University> getAll();
        public void delete(int id);
        public void update(University u);

    }
}
