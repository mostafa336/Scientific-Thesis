using Thesis.Models;
using Thesis.Repository;

namespace Thesis.Services
{
    public class UniversityService : IUniversityService
    {
            private readonly IUniversityRepository _UNI;
            public UniversityService(IUniversityRepository _UNI)
            {
                this._UNI = _UNI;
            }

            public IEnumerable<University> GetAll()
            {
                IEnumerable<University> universities = _UNI.GetAll(); //calling interface
                return universities;
            }

            public University? GetById(int? UniId)
            {
                if (UniId == null)
                {
                    return null;
                }
                var TUni = _UNI.GetById((int)UniId);
                return TUni;
            }
            public bool Insert(University u)
            {
                if (u == null)
                    return false;

                bool result = _UNI.Insert(u);
                return result;
            }
            public bool Update(University u)
            {
                bool result = _UNI.Update(u);
                return result;
            }
            public bool Delete(int? id)
            {
                if (id == null)
                {
                    return false;
                }

                bool result = _UNI.Delete((int)id);
                return result;
            }

            public bool Delete(University? TId)
            {
                throw new NotImplementedException();
            }
        }
    }

