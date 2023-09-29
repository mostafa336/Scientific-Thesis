using Thesis.Models;

namespace Thesis.Repository
{
    public interface IStatusRepository
    {
        public IEnumerable<Status> GetAll();
        public Status GetById(int id);

    }
}
