using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Billder.API.Models.Configurations
{
        public abstract class EntityTypeBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseModel
        {
            public void Configure(EntityTypeBuilder<T> builder)
            {
                ConfigurateProperties(builder);
                ConfigurateConstraints(builder);
                ConfigurateTableName(builder);
            }
            protected abstract void ConfigurateProperties(EntityTypeBuilder<T> builder);
            protected abstract void ConfigurateConstraints(EntityTypeBuilder<T> builder);
            protected abstract void ConfigurateTableName(EntityTypeBuilder<T> builder);
        }
}
