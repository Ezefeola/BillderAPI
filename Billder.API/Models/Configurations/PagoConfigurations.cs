using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Billder.API.Models.Configurations
{
    public class PagoConfigurations : EntityTypeBaseConfiguration<Pago>
    {
        protected override void ConfigurateConstraints(EntityTypeBuilder<Pago> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Trabajo).WithMany(p => p.Pago).HasForeignKey(p => p.TrabajoId);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<Pago> builder)
        {
            builder.Property(p => p.Monto).IsRequired().HasPrecision(18, 2);
            builder.Property(p => p.Metodo).IsRequired().HasMaxLength(50);
            builder.Property(p => p.FechaPago).IsRequired();
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<Pago> builder)
        {
            builder.ToTable("Pagos");
        }
    }
}
