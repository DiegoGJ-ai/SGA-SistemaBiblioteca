using Microsoft.EntityFrameworkCore;

namespace SGA.Persistence.Base;

public class BaseRepository<T> where T : class
{
    protected readonly DbContext Context;
    public BaseRepository(DbContext context) => Context = context;

    public virtual async Task<T?> GetByIdAsync(object id) => await Context.Set<T>().FindAsync(id);
    public virtual async Task<IReadOnlyList<T>> ListAsync() => await Context.Set<T>().AsNoTracking().ToListAsync();

    public virtual async Task AddAsync(T entity)
    {
        Context.Set<T>().Add(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        Context.Set<T>().Update(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        Context.Set<T>().Remove(entity);
        await Context.SaveChangesAsync();
    }
}
