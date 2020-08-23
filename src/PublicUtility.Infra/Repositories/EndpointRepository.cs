using Microsoft.EntityFrameworkCore;
using PublicUtility.Domain.Entities;
using PublicUtility.Domain.Queries;
using PublicUtility.Domain.Repositories;
using PublicUtility.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicUtility.Infra.Repositories
{
    public class EndpointRepository : IEndpointRepository
    {
        private readonly DataContext _context;

        public EndpointRepository(DataContext context)
        {
            _context = context;
        }

        public void Save(Endpoint endpoint)
        {
            _context.Endpoint.Add(endpoint);
            _context.SaveChanges();
        }

        public void Update(Endpoint endpoint)
        {
            _context.Entry(endpoint).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool Delete(string serialNumber)
        {
            try
            {
                _context.Remove(GetBySerialNumber(serialNumber));
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Endpoint> GetAll()
        {
            return _context.Endpoint.OrderBy(x => x.SerialNumber);
        }

        public Endpoint GetBySerialNumber(string serialNumber)
        {
            return _context.Endpoint.SingleOrDefault(EndpointQueries.GetBySerialNumber(serialNumber));
        }
              
        public bool SerialNumberExists(string serialNumber)
        {
            return _context.Endpoint.Any(EndpointQueries.GetBySerialNumber(serialNumber));
        }
    }
}
