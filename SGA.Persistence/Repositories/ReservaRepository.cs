using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities;
using SGA.Domain.Repository;
using SGA.Persistence.Context;

namespace SGA.Persistence.Repositories;

public class ReservaRepository : IReservaRepository
{
    private readonly LibraryContext _context;
    public ReservaRepository(LibraryContext context) => _context = context;

    public async Task CrearReservaAsync(int libroId)
    {
        _context.Reservas.Add(new Reserva { LibroId = libroId, Fecha = DateTime.UtcNow, Notificado = false });
        await _context.SaveChangesAsync();
    }

    public Task<Reserva?> SiguienteReservaAsync(int libroId) =>
        _context.Reservas.Where(r => r.LibroId == libroId && !r.Notificado)
                         .OrderBy(r => r.Fecha)
                         .FirstOrDefaultAsync();
}
