namespace LibrarySystem.Application.Common.Interfaces;

public interface IGenericRepository<TEntity>
    where TEntity : class
{
    Task<TEntity?> GetAsync(Guid id);
    Task<List<TEntity>> GetAllAsync();
    Task DeleteAsync(Guid id);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
}
