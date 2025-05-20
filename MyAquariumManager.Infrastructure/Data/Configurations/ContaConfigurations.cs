using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Infrastructure.Data.Configurations
{
    public class ContaConfigurations : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .HasOne(c => c.Usuario)
                .WithOne()
                .HasForeignKey<Conta>(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
