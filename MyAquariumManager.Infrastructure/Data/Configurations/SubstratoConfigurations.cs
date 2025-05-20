using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Infrastructure.Data.Configurations
{
    public class SubstratoConfigurations : IEntityTypeConfiguration<Substrato>
    {
        public void Configure(EntityTypeBuilder<Substrato> builder)
        {
            builder.HasKey(s => s.Id);
        }
    }
}
