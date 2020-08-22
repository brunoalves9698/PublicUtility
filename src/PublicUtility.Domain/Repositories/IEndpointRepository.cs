using PublicUtility.Domain.Entities;
using System.Collections.Generic;

namespace PublicUtility.Domain.Repositories
{
    public interface IEndpointRepository
    {
        void Save(Endpoint endpoint);
        void Update(Endpoint endpoint);
        void Delete(string serialNumber);
        Endpoint GetBySerialNumber(string id);
        IEnumerable<Endpoint> GetAll();
        bool SeriaNumberExists(string serialNumber);
    }
}
