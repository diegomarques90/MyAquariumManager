using MyAquariumManager.Core.Entities;
using MyAquariumManager.Core.Interfaces.Repositories;
using MyAquariumManager.Infrastructure.Data.Context;

namespace MyAquariumManager.Infrastructure.Data.Repositories
{
    public class PlantaRepository(MyAquariumManagerDbContext context) : BaseRepository<Planta>(context), IPlantaRepository
    {
    }
}
