using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Infrastructure.Data.Configurations
{
    public class HistoricoDeManutencaoConfigurations : IEntityTypeConfiguration<HistoricoDeManutencao>
    {
        public void Configure(EntityTypeBuilder<HistoricoDeManutencao> builder)
        {
            builder.HasKey(h => h.Id);
        }
    }
}
