using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Infrastructure.Data.Configurations
{
    public class TanqueConfigurations : IEntityTypeConfiguration<Tanque>
    {
        public void Configure(EntityTypeBuilder<Tanque> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
