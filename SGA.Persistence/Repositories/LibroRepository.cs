using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities;
using SGA.Domain.Repository;
using SGA.Persistence.Context;

namespace SGA.Persistence.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly LibraryContext _context;

        public LibroRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Libro libro)
        {
            await _context.Libros.AddAsync(libro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Libro?> GetByIdAsync(int id)
        {
            return await _context.Libros.FindAsync(id);
        }

        public async Task<IReadOnlyList<Libro>> ListAsync()
        {
            return await _context.Libros.ToListAsync();
        }

        public async Task UpdateAsync(Libro libro)
        {
            _context.Libros.Update(libro);
            await _context.SaveChangesAsync();
        }

        // ⚠️ Nuevo método requerido por la interfaz
        public async Task<IReadOnlyList<Libro>> BuscarPorAutorAsync(int autorId)
        {
            return await _context.Libros
                .Where(l => l.AutorId == autorId)
                .ToListAsync();
        }
    }
}
