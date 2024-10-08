using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Billder.API.Models.Configurations
{
    public class ContratoConfigurations : EntityTypeBaseConfiguration<Contrato>
    {
        protected override void ConfigurateConstraints(EntityTypeBuilder<Contrato> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Trabajo).WithOne(c => c.Contrato).HasForeignKey<Contrato>(c => c.TrabajoId);
        }

        protected override void ConfigurateProperties(EntityTypeBuilder<Contrato> builder)
        {
            builder.Property(c => c.Cliente).IsRequired().HasMaxLength(80);
            builder.Property(c => c.Condiciones).IsRequired().HasMaxLength(400);
            builder.Property(c => c.FirmaDigital).HasMaxLength(80);
        }

        protected override void ConfigurateTableName(EntityTypeBuilder<Contrato> builder)
        {
            builder.ToTable("Contrato");
        }
    }
}
