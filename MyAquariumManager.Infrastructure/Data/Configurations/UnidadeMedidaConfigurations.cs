using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Infrastructure.Data.Configurations
{
    public class UnidadeMedidaConfigurations : IEntityTypeConfiguration<UnidadeDeMedida>
    {
        public void Configure(EntityTypeBuilder<UnidadeDeMedida> builder)
        {
            builder.HasKey(um => um.Id);
        }
    }
}
