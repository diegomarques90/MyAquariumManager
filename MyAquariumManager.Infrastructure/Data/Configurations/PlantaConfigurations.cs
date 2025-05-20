using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Infrastructure.Data.Configurations
{
    public class PlantaConfigurations : IEntityTypeConfiguration<Planta>
    {
        public void Configure(EntityTypeBuilder<Planta> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
