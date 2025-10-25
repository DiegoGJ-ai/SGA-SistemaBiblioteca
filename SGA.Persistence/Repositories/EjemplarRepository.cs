using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities;
using SGA.Domain.Repository;
using SGA.Persistence.Base;
using SGA.Persistence.Context;

namespace SGA.Persistence.Repositories;

public class EjemplarRepository : BaseRepository<Ejemplar>, IEjemplarRepository
{
    public EjemplarRepository(LibraryContext context) : base(context) { }

    public async Task<Ejemplar?> GetDisponiblePorLibroAsync(int libroId)
    {
        return await _context.Ejemplares
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.LibroId == libroId);
    }
}
