using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Infrastructure.Data.Context
{
    public class MyAquariumManagerDbContext(DbContextOptions<MyAquariumManagerDbContext> options) : IdentityDbContext<Usuario>(options)
    {
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<HistoricoDeManutencao> HistoricoDeManutencao { get; set; }
        public DbSet<ItemNoTanque> ItemNoTanque { get; set; }
        public DbSet<Pedra> Pedra { get; set; }
        public DbSet<Planta> Planta { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Substrato> Substrato { get; set; }
        public DbSet<Tanque> Tanque { get; set; }
        public DbSet<UnidadeDeMedida> UnidadeDeMedidas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            CriarIdentityRoles(builder);
            base.OnModelCreating(builder);
        }

        private static void CriarIdentityRoles(ModelBuilder builder)
        {
            var administrador = new IdentityRole("administrador");
            administrador.NormalizedName = "ADMINISTRADOR";

            var convidado = new IdentityRole("convidado");
            convidado.NormalizedName = "CONVIDADO";

            builder.Entity<IdentityRole>().HasData(administrador, convidado);
        }
    }
}
