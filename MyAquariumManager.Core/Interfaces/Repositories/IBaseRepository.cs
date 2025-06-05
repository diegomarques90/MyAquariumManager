namespace MyAquariumManager.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(Guid id, string usuarioExclusao);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}
