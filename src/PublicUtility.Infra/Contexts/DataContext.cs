using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using PublicUtility.Domain.Entities;
using PublicUtility.Domain.Shared;
using PublicUtility.Infra.Contexts.Maps;

namespace PublicUtility.Infra.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(Settings.ConnectionString);
        }

        public DbSet<Endpoint> Endpoint { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Notification>();

            builder.ApplyConfiguration(new EndpointMap());
        }
    }
}
