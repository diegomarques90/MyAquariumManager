using Microsoft.EntityFrameworkCore;
using MyAquariumManager.Application.DTOs.Animal;
using MyAquariumManager.Application.DTOs.Planta;
using MyAquariumManager.Application.Helpers;
using MyAquariumManager.Application.Interfaces.Services;
using MyAquariumManager.Core.Common;
using MyAquariumManager.Core.Constants;
using MyAquariumManager.Core.Enums;
using MyAquariumManager.Core.Interfaces.Repositories;

namespace MyAquariumManager.Application.Services
{
    public class PlantaService(IPlantaRepository plantaRepository) : IPlantaService
    {
        private readonly IPlantaRepository _plantaRepository = plantaRepository;

        public async Task<Result<PlantaDto>> AtualizarPlantaAsync(AtualizarPlantaDto model)
        {
            var planta = await _plantaRepository.GetByIdAsync(model.Id);

            if (planta is null)
                return Result<PlantaDto>.Failure([BaseConstants.PLANTA_NAO_EXISTE_OU_JA_FOI_EXCLUIDA]);

            var (isValid, errors) = planta.Validate();

            if (!isValid)
                return Result<PlantaDto>.Failure(errors);

            try
            {
                await _plantaRepository.UpdateAsync(planta);
                await _plantaRepository.SaveChangesAsync();

                var plantaDto = PlantaHelper.ObterPlantaDto(planta);
                return Result<PlantaDto>.Success(plantaDto, HttpCode.OK);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Erro ao persistir dados na atualização da planta: {dbEx.Message}");
                return Result<PlantaDto>.Failure(["Erro de persistência atualizar a planta. Tente novamente mais tarde."]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar plantas: {ex.Message}");
                return Result<PlantaDto>.Failure([$"Ocorreu um erro inesperado ao atualizar a planta: {ex.Message}"]);
            }
        }

        public async Task<Result<PlantaDto>> CadastrarPlantaAsync(CriarPlantaDto model)
        {
            var planta = PlantaHelper.ObterPlanta(model);

            var (isValid, errors) = planta.Validate();

            if (!isValid)
                return Result<PlantaDto>.Failure(errors);

            try
            {
                await _plantaRepository.AddAsync(planta);
                await _plantaRepository.SaveChangesAsync();

                var plantaDto = PlantaHelper.ObterPlantaDto(planta);
                return Result<PlantaDto>.Success(plantaDto, HttpCode.Created);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Erro ao persistir dados no cadastro da planta: {dbEx.Message}");
                return Result<PlantaDto>.Failure(["Erro de persistência ao cadastrar a planta. Tente novamente mais tarde."]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar plantas: {ex.Message}");
                return Result<PlantaDto>.Failure([$"Ocorreu um erro inesperado ao cadastrar a planta: {ex.Message}"]);
            }
        }

        public Task<Result<DataTableResult<TablePlantaDto>>> CarregarTablePlantasAsync(DataTableFilters dataTableFilters)
        {
            throw new NotImplementedException();
        }

        public Task<Result> ExcluirPlantaAsync(Guid id, string usuarioExclusao)
        {
            throw new NotImplementedException();
        }

        public Task<Result<PlantaDto>> ObterPlantaPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
