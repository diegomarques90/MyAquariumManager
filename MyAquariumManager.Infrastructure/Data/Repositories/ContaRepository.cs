using Microsoft.EntityFrameworkCore;
using MyAquariumManager.Core.Entities;
using MyAquariumManager.Core.Interfaces.Repositories;
using MyAquariumManager.Infrastructure.Data.Context;

namespace MyAquariumManager.Infrastructure.Data.Repositories
{
    public class ContaRepository(MyAquariumManagerDbContext context) : BaseRepository<Conta>(context), IContaRepository
    {
        public async Task<bool> ExisteContaComOCodigo(string codigoConta)
        {
            return await _context.Conta
                .AsNoTracking()
                .AnyAsync(conta => conta.CodigoConta == codigoConta);
        }
    }
}
