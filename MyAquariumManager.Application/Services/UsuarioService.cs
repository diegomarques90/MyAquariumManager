using MyAquariumManager.Application.DTOs.Usuario;
using MyAquariumManager.Application.Helpers;
using MyAquariumManager.Application.Interfaces.Services;
using MyAquariumManager.Core.Common;
using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Interfaces.Repositories;

namespace MyAquariumManager.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Result<UsuarioSessionDto>> ObterUsuarioSessionDtoPorEmailAsync(string email)
        {
            try
            {
                var usuario = await _usuarioRepository.ObterUsuarioPorEmailAsync(email);

                if (usuario is null)
                    return Result<UsuarioSessionDto>.Failure([BaseConstants.USUARIO_NAO_EXISTE_OU_JA_FOI_EXCLUIDO]);

                var usuarioSessionDto = UsuarioHelper.ObterUsuarioSessionDto(usuario);
                return Result<UsuarioSessionDto>.Success(usuarioSessionDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar o usuário por email: {ex.Message}");
                return Result<UsuarioSessionDto>.Failure([$"Ocorreu um erro inesperado ao buscar o usuario por email: {ex.Message}"]);
            }
        }

        public async Task<Result<UsuarioSessionDto>> ObterUsuarioSessionDtoPorIdAsync(string usuarioId)
        {
            try
            {
                var usuario = await _usuarioRepository.ObterUsuarioPorIdAsync(usuarioId);

                if (usuario is null)
                    return Result<UsuarioSessionDto>.Failure([BaseConstants.USUARIO_NAO_EXISTE_OU_JA_FOI_EXCLUIDO]);

                var usuarioSessionDto = UsuarioHelper.ObterUsuarioSessionDto(usuario);
                return Result<UsuarioSessionDto>.Success(usuarioSessionDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar o usuário por id: {ex.Message}");
                return Result<UsuarioSessionDto>.Failure([$"Ocorreu um erro inesperado ao buscar o usuario por id: {ex.Message}"]);
            }
        }
    }
}
