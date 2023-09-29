using Thesis.Models;
using Thesis.Repository;

namespace Thesis.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _IStatusRepository;
        public StatusService(IStatusRepository IstatusRepository)
        {
            _IStatusRepository = IstatusRepository;
        }
        public IEnumerable<Status> GetAll()
        {
            return _IStatusRepository.GetAll();
        }

        public Status GetById(int id) {
            return _IStatusRepository.GetById(id);
        }
    }
}
