using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PublicUtility.Domain.Entities;

namespace PublicUtility.Infra.Contexts.Maps
{
    public class EndpointMap : IEntityTypeConfiguration<Endpoint>
    {
        public void Configure(EntityTypeBuilder<Endpoint> builder)
        {
            builder.ToTable("Endpoint");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.SerialNumber)
               .IsRequired()
               .HasColumnType("int");

            builder.Property(x => x.MeterModelId)
               .IsRequired()
               .HasColumnType("int");

            builder.Property(x => x.MeterNumber)
               .IsRequired()
               .HasColumnType("int");

            builder.Property(x => x.MeterFirmwareVersion)
              .IsRequired()
              .HasMaxLength(100)
              .HasColumnType("varchar(100)");

            builder.Property(x => x.SwitchState)
             .IsRequired()
             .HasColumnType("int");
        }
    }
}
