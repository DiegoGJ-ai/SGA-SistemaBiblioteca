using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities;
using SGA.Domain.Repository;
using SGA.Persistence.Base;
using SGA.Persistence.Context;

namespace SGA.Persistence.Repositories;

public class LibroRepository : BaseRepository<Libro>, ILibroRepository
{
    private readonly LibraryContext _context;
    public LibroRepository(LibraryContext context) : base(context) => _context = context;

    public new Task<Libro?> GetByIdAsync(int id) =>
        _context.Libros.AsNoTracking()
                       .Include(x => x.Autor)
                       .FirstOrDefaultAsync(x => x.Id == id)!;

    public new async Task<IReadOnlyList<Libro>> ListAsync() =>
        await _context.Libros.AsNoTracking()
                             .Include(x => x.Autor)
                             .OrderBy(x => x.Titulo)
                             .ToListAsync();

    public async Task DeleteAsync(int id)
    {
        var e = await _context.Libros.FindAsync(id);
        if (e is null) return;
        _context.Libros.Remove(e);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Libro>> BuscarPorAutorAsync(int autorId) =>
        await _context.Libros.AsNoTracking()
                             .Where(x => x.AutorId == autorId)
                             .ToListAsync();
}
