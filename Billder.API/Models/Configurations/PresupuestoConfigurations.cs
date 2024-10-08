using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Billder.API.Models.Configurations
{
    public class PresupuestoConfigurations : EntityTypeBaseConfiguration<Presupuesto>
    {
        protected override void ConfigurateConstraints(EntityTypeBuilder<Presupuesto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Trabajo).WithOne(p => p.Presupuesto).HasForeignKey<Presupuesto>(p => p.TrabajoId);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<Presupuesto> builder)
        {
            builder.Property(p => p.Materiales).IsRequired().HasMaxLength(450);
            builder.Property(p => p.PrecioMateriales).IsRequired().HasPrecision(18,2);
            builder.Property(p => p.DescripcionManoDeObra).IsRequired().HasMaxLength(500);
            builder.Property(p => p.PrecioManoDeObra).IsRequired().HasPrecision(18,2);
            builder.Property(p => p.Total).HasPrecision(18, 2);
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<Presupuesto> builder)
        {
            builder.ToTable("Presupuestos");
        }
    }
}
