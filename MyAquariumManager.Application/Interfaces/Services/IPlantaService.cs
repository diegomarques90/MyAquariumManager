using MyAquariumManager.Application.DTOs.Planta;
using MyAquariumManager.Core.Common;

namespace MyAquariumManager.Application.Interfaces.Services
{
    public interface IPlantaService
    {
        Task<Result<PlantaDto>> CadastrarPlantaAsync(CriarPlantaDto model);
        Task<Result<PlantaDto>> AtualizarPlantaAsync(AtualizarPlantaDto model);
        Task<Result> ExcluirPlantaAsync(Guid id, string usuarioExclusao);
        Task<Result<DataTableResult<TablePlantaDto>>> CarregarTablePlantasAsync(DataTableFilters dataTableFilters);
        Task<Result<PlantaDto>> ObterPlantaPorIdAsync(Guid id);

    }
}
