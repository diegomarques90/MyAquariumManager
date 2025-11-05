using MyAquariumManager.Core.Common;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Core.Interfaces.Repositories
{
    public interface IPlantaRepository : IBaseRepository<Planta>
    {
        Task<List<Planta>> ObterDataTableAsync(DataTableFilters dataTableFilters);
    }
}
