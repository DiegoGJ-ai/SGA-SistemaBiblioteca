using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities;
using SGA.Domain.Repository;
using SGA.Persistence.Contexts;

namespace SGA.Persistence.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly SgaDbContext _db;
        public LibroRepository(SgaDbContext db) => _db = db;

        public Task<Libro?> GetByIdAsync(int id) =>
            _db.Libros.FirstOrDefaultAsync(x => x.Id == id)!;

        public async Task<IReadOnlyList<Libro>> ListAsync() =>
            await _db.Libros.AsNoTracking().ToListAsync();

        public async Task AddAsync(Libro entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
        }
    }
}
