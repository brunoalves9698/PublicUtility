using PublicUtility.Domain.Entities;
using System.Collections.Generic;

namespace PublicUtility.Domain.Repositories
{
    public interface IEndpointRepository
    {
        void Save(Endpoint endpoint);
        void Update(Endpoint endpoint);
        bool Delete(string serialNumber);
        Endpoint GetBySerialNumber(string serialNumber);
        IEnumerable<Endpoint> GetAll();
        bool SerialNumberExists(string serialNumber);
    }
}
