using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities;
using SGA.Domain.Repository;
using SGA.Persistence.Context;

namespace SGA.Persistence.Repositories;

public class EjemplarRepository : IEjemplarRepository
{
    private readonly LibraryContext _context;
    public EjemplarRepository(LibraryContext context) => _context = context;

    public Task<Ejemplar?> GetDisponiblePorLibroAsync(int libroId) =>
        _context.Ejemplares.FirstOrDefaultAsync(x => x.LibroId == libroId && x.Disponible);
}
