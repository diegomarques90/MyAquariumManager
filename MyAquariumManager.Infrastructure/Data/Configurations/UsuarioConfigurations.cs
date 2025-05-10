using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Infrastructure.Data.Configurations
{
    public class UsuarioConfigurations : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
        }
    }
}
