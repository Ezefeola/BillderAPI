using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Billder.API.Models.Configurations
{
    public class GastoConfigurations : EntityTypeBaseConfiguration<Gasto>
    {
        protected override void ConfigurateConstraints(EntityTypeBuilder<Gasto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Presupuesto).WithMany(x => x.Gastos).HasForeignKey(x => x.PresupuestoId);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<Gasto> builder)
        {
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Precio).IsRequired().HasPrecision(18,2);
            builder.Property(x => x.Cantidad).IsRequired();
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<Gasto> builder)
        {
            builder.ToTable("Gastos");
        }
    }
}
