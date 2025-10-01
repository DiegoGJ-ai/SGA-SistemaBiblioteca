using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities;
using SGA.Domain.Repository;
using SGA.Persistence.Base;
using SGA.Persistence.Context;

namespace SGA.Persistence.Repositories;

public class AutorRepository : BaseRepository<Autor>, IAutorRepository
{
    private readonly LibraryContext _context;
    public AutorRepository(LibraryContext context) : base(context) => _context = context;

    public new Task<Autor?> GetByIdAsync(int id) =>
        _context.Autores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id)!;

    public new async Task<IReadOnlyList<Autor>> ListAsync() =>
        await _context.Autores.AsNoTracking().OrderBy(x => x.Nombre).ToListAsync();

    public async Task DeleteAsync(int id)
    {
        var e = await _context.Autores.FindAsync(id);
        if (e is null) return;
        _context.Autores.Remove(e);
        await _context.SaveChangesAsync();
    }
}
