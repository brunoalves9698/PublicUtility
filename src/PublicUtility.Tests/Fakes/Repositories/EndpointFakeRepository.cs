using PublicUtility.Domain.Entities;
using PublicUtility.Domain.Enums;
using PublicUtility.Domain.Repositories;
using System.Collections.Generic;

namespace PublicUtility.Tests.Fakes.Repositories
{
    public class EndpointFakeRepository : IEndpointRepository
    {
        public void Save(Endpoint endpoint)
        {
         
        }

        public void Update(Endpoint endpoint)
        {
         
        }

        public bool Delete(string serialNumber)
        {
            return true;
        }

        public IEnumerable<Endpoint> GetAll()
        {
            return new List<Endpoint>();
        }

        public Endpoint GetBySerialNumber(string serialNumber)
        {
            if (serialNumber == "1")
                return new Endpoint(serialNumber, 1, 1, "v 0.0.1", EEndpointState.Connected);

            return null;
        }

        public bool SerialNumberExists(string serialNumber)
        {
            return serialNumber == "1" ? true : false;
        }
    }
}
