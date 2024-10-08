using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Billder.API.Models.Configurations
{
    public class TrabajoConfigurations : EntityTypeBaseConfiguration<Trabajo>
    {
        protected override void ConfigurateConstraints(EntityTypeBuilder<Trabajo> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasMany(t => t.Pago).WithOne(t => t.Trabajo).HasForeignKey(t => t.TrabajoId);
            builder.HasOne(t => t.Presupuesto).WithOne(t => t.Trabajo).HasForeignKey<Presupuesto>(t => t.TrabajoId);
            builder.HasOne(t => t.Contrato).WithOne(t => t.Trabajo).HasForeignKey<Contrato>(t => t.TrabajoId);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<Trabajo> builder)
        {
            builder.Property(t => t.Cliente).IsRequired().HasMaxLength(80);
            builder.Property(t => t.Description).IsRequired().HasMaxLength(500);
            builder.Property(t => t.Fecha).IsRequired();
            builder.Property(t => t.Estado).IsRequired().HasMaxLength(40);
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<Trabajo> builder)
        {
            builder.ToTable("Trabajos");
        }
    }
}
