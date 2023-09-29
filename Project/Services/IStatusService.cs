using Thesis.Models;

namespace Thesis.Services
{
    public interface IStatusService
    {
        public IEnumerable<Status> GetAll();
        public Status GetById(int id);
    }
}
