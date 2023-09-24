using Thesis.Models;

namespace Thesis.Repository
{
    public interface IApplicationRepository
    {
        IEnumerable<FirstApplication> GetAll();
        FirstApplication GetByIdOrginal(int appId);
        bool Insert(FirstApplication app, ModifiedApplication edit);
        bool Update(ModifiedApplication edit);
        bool Delete(int appId);
    }
}
