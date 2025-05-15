using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Infrastructure.Data.Configurations
{
    public class ItemNoTanqueConfigurations : IEntityTypeConfiguration<ItemNoTanque>
    {
        public void Configure(EntityTypeBuilder<ItemNoTanque> builder)
        {
            builder.HasKey(it => it.Id);

            builder.HasOne(it => it.UnidadeDeMedida)
                .WithOne()
                .HasForeignKey<ItemNoTanque>(it => it.UnidadeDeMedidaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
