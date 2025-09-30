using Microsoft.EntityFrameworkCore;
using MyAquariumManager.Core.Common;
using MyAquariumManager.Core.Entities;
using MyAquariumManager.Core.Interfaces.Repositories;
using MyAquariumManager.Infrastructure.Data.Context;
using System.Linq.Dynamic.Core;

namespace MyAquariumManager.Infrastructure.Data.Repositories
{
    public class AnimalRepository(MyAquariumManagerDbContext context) : BaseRepository<Animal>(context), IAnimalRepository
    {
        public async Task<List<Animal>> ObterDataTableAsync(DataTableFilters dataTableFilters)
        {
            var query = _context.Animal.AsQueryable();

            if (!string.IsNullOrEmpty(dataTableFilters.SortColumnName))
            {
                var orderString = $"{dataTableFilters.SortColumnName} {dataTableFilters.SortDirection}";
                query = query.OrderBy(orderString);
            }

            return await query
                .Skip(dataTableFilters.Start)
                .Take(dataTableFilters.Length)
                .ToListAsync();
        }
    }
}
