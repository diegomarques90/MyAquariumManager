using Microsoft.EntityFrameworkCore;
using MyAquariumManager.Core.Entities;
using MyAquariumManager.Core.Interfaces.Repositories;
using MyAquariumManager.Infrastructure.Data.Context;

namespace MyAquariumManager.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MyAquariumManagerDbContext _context;

        public UsuarioRepository(MyAquariumManagerDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObterUsuarioPorEmailAsync(string email)
        {
            return await _context.Usuario.FirstOrDefaultAsync(usuario => usuario.Email == email);
        }

        public async Task<Usuario> ObterUsuarioPorIdAsync(string usuarioId)
        {
            return await _context.Usuario.FirstOrDefaultAsync(usuario => usuario.Id == usuarioId);
        }
    }
}
