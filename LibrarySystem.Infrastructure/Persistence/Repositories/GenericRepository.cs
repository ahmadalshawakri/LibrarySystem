using LibrarySystem.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Infrastructure.Persistence.Repositories;

public class GenericsRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericsRepository(AppDbContext context)
    {
        this._context = context;
        this._dbSet = context.Set<TEntity>();
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        TEntity entity = await GetAsync(id);
        if (entity != null)
            _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity> GetAsync(Guid id)
    {
        if (id == null)
            return null;
        return await _dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
}
