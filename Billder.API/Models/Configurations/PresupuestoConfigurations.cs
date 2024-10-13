using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Billder.API.Models.Configurations
{
    public class PresupuestoConfigurations : EntityTypeBaseConfiguration<Presupuesto>
    {
        protected override void ConfigurateConstraints(EntityTypeBuilder<Presupuesto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Trabajo).WithMany(p => p.Presupuesto).HasForeignKey(p => p.TrabajoId);
            builder.HasMany(p => p.Gastos).WithOne(p => p.Presupuesto).HasForeignKey(p => p.PresupuestoId);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<Presupuesto> builder)
        {
            builder.Property(p => p.Total).HasPrecision(18, 2);
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<Presupuesto> builder)
        {
            builder.ToTable("Presupuestos");
        }
    }
}
