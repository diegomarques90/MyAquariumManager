using Microsoft.EntityFrameworkCore;
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

        public async Task<Result<DataTableResult<TablePlantaDto>>> CarregarTablePlantasAsync(DataTableFilters dataTableFilters)
        {
            try
            {
                var plantas = await _plantaRepository.ObterDataTableAsync(dataTableFilters);
                var plantasTableDto = PlantaHelper.ObterListaDeTabelaPlantaDto(plantas);
                var dataTable = new DataTableResult<TablePlantaDto>
                {
                    Dados = plantasTableDto,
                    TotalFiltrado = plantasTableDto.Count,
                    TotalGeral = plantasTableDto.Count
                };

                return Result<DataTableResult<TablePlantaDto>>.Success(dataTable);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Erro de persistência ao carregar a tabela plantas: {dbEx.Message}");
                return Result<DataTableResult<TablePlantaDto>>.Failure(["Erro de persistência ao carregar a tabela plantas. Tente novamente mais tarde."]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar a tabela plantas: {ex.Message}");
                return Result<DataTableResult<TablePlantaDto>>.Failure([$"Ocorreu um erro inesperado ao carregar a tabela plantas: {ex.Message}"]);
            }
        }

        public async Task<Result> ExcluirPlantaAsync(Guid id, string usuarioExclusao)
        {
            try
            {
                var planta = await _plantaRepository.GetByIdAsync(id);

                if (planta is null)
                    return Result.Failure([BaseConstants.PLANTA_NAO_EXISTE_OU_JA_FOI_EXCLUIDA]);

                planta.Inativar(usuarioExclusao);
                await _plantaRepository.UpdateAsync(planta);
                await _plantaRepository.SaveChangesAsync();

                return Result.Success();
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Erro ao persistir dados na exclusão de plantas: {dbEx.Message}");
                return Result.Failure(["Erro de persistência ao excluir o planta. Tente novamente mais tarde."]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao excluir plantas: {ex.Message}");
                return Result.Failure([$"Ocorreu um erro inesperado ao excluir o planta: {ex.Message}"]);
            }
        }

        public async Task<Result<PlantaDto>> ObterPlantaPorIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    return Result<PlantaDto>.Failure([BaseConstants.ID_NAO_PODE_SER_NULO_OU_VAZIO]);

                var planta = await _plantaRepository.GetByIdAsync(id);

                if (planta is null)
                    return Result<PlantaDto>.Failure([BaseConstants.PLANTA_NAO_EXISTE_OU_JA_FOI_EXCLUIDA]);

                var plantaDto = PlantaHelper.ObterPlantaDto(planta);
                return Result<PlantaDto>.Success(plantaDto);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Erro de persistência ao obter a planta: {dbEx.Message}");
                return Result<PlantaDto>.Failure(["Erro de persistência ao obter a planta. Tente novamente mais tarde."]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter a planta: {ex.Message}");
                return Result<PlantaDto>.Failure([$"Ocorreu um erro inesperado ao obter a planta: {ex.Message}"]);
            }
        }

        public async Task<Result<List<PlantaDto>>> ObterPlantasAsync()
        {
            try
            {
                var plantas = await _plantaRepository.GetAllAsync();
                var plantasDtos = PlantaHelper.ObterListaDePlantaDto(plantas);

                return Result<List<PlantaDto>>.Success(plantasDtos);
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Erro de persistência ao obter a lista de todas as plantas: {dbEx.Message}");
                return Result<List<PlantaDto>>.Failure(["Erro de persistência ao obter a lista de todas as plantas. Tente novamente mais tarde."]);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter a lista de todas as plantas: {ex.Message}");
                return Result<List<PlantaDto>>.Failure([$"Ocorreu um erro inesperado ao obter a lista de todas as plantas: {ex.Message}"]);
            }
        }
    }
}
