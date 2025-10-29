using MyAquariumManager.Application.DTOs.Planta;
using MyAquariumManager.Application.Interfaces.Services;
using MyAquariumManager.Core.Common;

namespace MyAquariumManager.Application.Services
{
    public class PlantaService : IPlantaService
    {
        public Task<Result<PlantaDto>> AtualizarPlantaAsync(AtualizarPlantaDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Result<PlantaDto>> CadastrarPlantaAsync(CriarPlantaDto model)
        {
            throw new NotImplementedException();
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
