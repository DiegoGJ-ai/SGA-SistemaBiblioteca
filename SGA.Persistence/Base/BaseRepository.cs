using Microsoft.EntityFrameworkCore;
using SGA.Domain.Repository;
using SGA.Persistence.Context;

namespace SGA.Persistence.Base;

public class BaseRepository<T> : IRepositoryBase<T> where T : class
{
    protected readonly LibraryContext _context;

    public BaseRepository(LibraryContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<T>> ListAsync()
        => await _context.Set<T>().AsNoTracking().ToListAsync();

    public async Task<T?> GetByIdAsync(int id)
        => await _context.Set<T>().FindAsync(id);

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null) return;
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}
