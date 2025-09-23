using Microsoft.EntityFrameworkCore;
using MyAquariumManager.Application.DTOs.Conta;
using MyAquariumManager.Application.Interfaces.Services;
using MyAquariumManager.Application.Mappers;
using MyAquariumManager.Core.Common;
using MyAquariumManager.Core.Entities;
using MyAquariumManager.Core.Enums;
using MyAquariumManager.Core.Interfaces.Repositories;

namespace MyAquariumManager.Application.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository contaRespository)
        {
            _contaRepository = contaRespository;
        }

        public async Task<Result<ContaDto>> CriarContaAsync(CriarContaDto dto)
        {
            var conta = ContaHelper.ObterConta(dto);
            
            var resultCodigoConta = await CriarCodigoContaAsync(conta);
            if (resultCodigoConta.IsFailure)
                return Result<ContaDto>.Failure(resultCodigoConta.Errors);
            
            conta.CodigoConta = resultCodigoConta.Value;

            var (isValid, errors) = conta.Validate();

            if (!isValid)
                return Result<ContaDto>.Failure(errors);

            try
            {
                await _contaRepository.AddAsync(conta);
                await _contaRepository.SaveChangesAsync();

                var contaDto = ContaHelper.ObterContaDto(conta);
                return Result<ContaDto>.Success(contaDto, HttpCode.Created);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Erro ao persistir dados no cadastro da conta: {dbEx.Message}");
                return Result<ContaDto>.Failure(["Erro de persistência ao cadastrar a conta. Tente novamente mais tarde."]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar conta: {ex.Message}");
                return Result<ContaDto>.Failure([$"Ocorreu um erro inesperado ao cadastrar a conta: {ex.Message}"]);
            }
        }

        private async Task<Result<string>> CriarCodigoContaAsync(Conta conta)
        {
            var result = conta.CriarCodigoConta();

            if (result.IsFailure)
                return result;

            var contaExiste = await _contaRepository.ExisteContaComOCodigo(result.Value);

            if (contaExiste)
                return Result<string>.Failure([$"Já existe conta cadastrada com o código: {conta.CodigoConta}"]);

            return result;
        }
    }
}
