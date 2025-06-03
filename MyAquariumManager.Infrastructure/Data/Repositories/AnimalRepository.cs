using MyAquariumManager.Core.Entities;
using MyAquariumManager.Core.Interfaces.Repositories;
using MyAquariumManager.Infrastructure.Data.Context;

namespace MyAquariumManager.Infrastructure.Data.Repositories
{
    public class AnimalRepository(MyAquariumManagerDbContext context) : BaseRepository<Animal>(context), IAnimalRepository
    {
    }
}
