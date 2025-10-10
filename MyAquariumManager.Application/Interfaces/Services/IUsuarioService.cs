using MyAquariumManager.Application.DTOs.Usuario;
using MyAquariumManager.Core.Common;

namespace MyAquariumManager.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<Result<UsuarioSessionDto>> ObterUsuarioSessionDtoPorIdAsync(string usuarioId);
        Task<Result<UsuarioSessionDto>> ObterUsuarioSessionDtoPorEmailAsync(string email);
    }
}
