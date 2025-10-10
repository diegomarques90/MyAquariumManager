using MyAquariumManager.Application.DTOs.Usuario;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Application.Helpers
{
    public static class UsuarioHelper
    {
        public static UsuarioSessionDto ObterUsuarioSessionDto(Usuario usuario) 
        { 
            return new UsuarioSessionDto 
            { 
                Email = usuario.Email ?? string.Empty
            };
        }
    }
}
