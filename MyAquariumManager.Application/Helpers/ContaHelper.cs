using MyAquariumManager.Application.DTOs.Conta;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Application.Mappers
{
    public static class ContaHelper
    {
        public static Conta ObterConta(CriarContaDto dto)
        {
            return new Conta(dto.UsuarioCriacao, dto.Nome, dto.UsuarioId);
        }

        public static ContaDto ObterContaDto(Conta conta)
        {
            return new ContaDto
            {
                Id = conta.Id,
                Nome = conta.Nome,
                CodigoConta = conta.CodigoConta,
            };
        }
    }
}
