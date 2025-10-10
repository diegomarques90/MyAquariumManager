using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Core.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterUsuarioPorIdAsync(string usuarioId);
        Task<Usuario> ObterUsuarioPorEmailAsync(string email);
    }
}
