using BaseTestApp.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BaseTestApp.DataAccess.Repository;

public interface IGenericRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }

    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> filter);
    Task<T?> GetSingleAsync(Expression<Func<T, bool>> filter);
    Task<int> GetCountAsync();
    Task<int> GetCountAsync(Expression<Func<T, bool>> filter);

    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task DeleteByIdAsync(int id);
    Task DeleteRangeAsync(IEnumerable<int> ids);
    Task SaveChangesAsync();
}

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly DataContext _context;
    public GenericRepository(DataContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<T?> GetByIdAsync(int id)
    {
        return await Table.FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await Table.AsNoTracking().Where(x => x.IsActive).ToListAsync();
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
    {
        return await Table.AsNoTracking().Where(filter).ToListAsync();
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter)
    {
        return Table.AsNoTracking().Where(filter);
    }

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> filter)
    {
        return await Table.AsNoTracking().FirstOrDefaultAsync(filter);
    }

    public async Task<int> GetCountAsync()
    {
        return await Table.CountAsync();
    }

    public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter)
    {
        return await Table.CountAsync(filter);
    }

    public async Task AddAsync(T entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        await Table.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            entity.CreatedDate = DateTime.UtcNow;
        }
        await Table.AddRangeAsync(entities);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
        Table.Update(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        Table.Remove(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            await DeleteAsync(entity);
        }
    }

    public async Task DeleteRangeAsync(IEnumerable<int> ids)
    {
        var entities = await Table.Where(x => ids.Contains(x.Id)).ToListAsync();
        Table.RemoveRange(entities);
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
