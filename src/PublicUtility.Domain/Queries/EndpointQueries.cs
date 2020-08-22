using PublicUtility.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace PublicUtility.Domain.Queries
{
    public class EndpointQueries
    {
        public static Expression<Func<Endpoint, bool>> GetBySerialNumber(string serialNumber)
        {
            return x => x.SerialNumber == serialNumber;
        }
    }
}
