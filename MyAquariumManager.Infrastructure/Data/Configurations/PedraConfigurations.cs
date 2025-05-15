using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Infrastructure.Data.Configurations
{
    public class PedraConfigurations : IEntityTypeConfiguration<Pedra>
    {
        public void Configure(EntityTypeBuilder<Pedra> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
