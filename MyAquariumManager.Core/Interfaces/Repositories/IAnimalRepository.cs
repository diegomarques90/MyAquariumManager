using MyAquariumManager.Core.Common;
using MyAquariumManager.Core.Entities;

namespace MyAquariumManager.Core.Interfaces.Repositories
{
    public interface IAnimalRepository : IBaseRepository<Animal>
    {
        Task<List<Animal>> ObterDataTableAsync(DataTableFilters dataTableFilters);
    }
}
