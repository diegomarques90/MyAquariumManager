using MyAquariumManager.Application.DTOs.Conta;
using MyAquariumManager.Core.Common;

namespace MyAquariumManager.Application.Interfaces.Services
{
    public interface IContaService
    {
        Task<Result<ContaDto>> CriarContaAsync(CriarContaDto dto);
    }
}
