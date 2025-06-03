using Microsoft.EntityFrameworkCore;
using MyAquariumManager.Core.Entities;
using MyAquariumManager.Core.Interfaces.Repositories;
using MyAquariumManager.Infrastructure.Data.Context;

namespace MyAquariumManager.Infrastructure.Data.Repositories
{
    public class BaseRepository<T>(MyAquariumManagerDbContext context) : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly MyAquariumManagerDbContext _context = context;

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync(T entity, string usuarioAlteracao)
        {
            entity.Atualizar(usuarioAlteracao);
            _context.Set<T>().Update(entity);
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }

        public async Task DeleteAsync(Guid id, string usuarioExclusao) // Recebe o usuarioExclusao
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
                return;
            
            entity.Inativar(usuarioExclusao);
            _context.Set<T>().Update(entity); 
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().Where(e => e.Ativo).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id && e.Ativo);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
