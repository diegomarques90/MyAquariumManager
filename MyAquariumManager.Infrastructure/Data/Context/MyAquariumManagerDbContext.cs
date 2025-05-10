using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Infrastructure.Data.Context
{
    public class MyAquariumManagerDbContext : IdentityDbContext<Usuario>
    {
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
