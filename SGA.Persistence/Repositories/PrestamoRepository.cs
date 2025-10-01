using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities;
using SGA.Domain.Repository;
using SGA.Persistence.Context;

namespace SGA.Persistence.Repositories;

public class PrestamoRepository : IPrestamoRepository
{
    private readonly LibraryContext _context;
    public PrestamoRepository(LibraryContext context) => _context = context;

    public Task<Prestamo?> GetByIdAsync(int id) =>
        _context.Prestamos.Include(p => p.Ejemplar).FirstOrDefaultAsync(x => x.Id == id)!;

    public async Task<IReadOnlyList<Prestamo>> ListPendientesAsync() =>
        await _context.Prestamos.AsNoTracking().Where(x => x.Devuelto == null).ToListAsync();

    public async Task<Prestamo> CrearPrestamoAsync(int ejemplarId, DateTime vence)
    {
        using var tx = await _context.Database.BeginTransactionAsync();

        var ej = await _context.Ejemplares.FirstOrDefaultAsync(x => x.Id == ejemplarId && x.Disponible);
        if (ej is null) throw new InvalidOperationException("Ejemplar no disponible");

        ej.Disponible = false;
        var p = new Prestamo { EjemplarId = ejemplarId, Fecha = DateTime.UtcNow, Vence = vence };
        _context.Prestamos.Add(p);
        await _context.SaveChangesAsync();

        await tx.CommitAsync();
        return p;
    }

    public async Task MarcarDevolucionAsync(int prestamoId)
    {
        using var tx = await _context.Database.BeginTransactionAsync();

        var p = await _context.Prestamos.Include(x => x.Ejemplar).FirstOrDefaultAsync(x => x.Id == prestamoId);
        if (p is null || p.Devuelto != null) return;

        p.Devuelto = DateTime.UtcNow;
        if (p.Ejemplar != null) p.Ejemplar.Disponible = true;

        await _context.SaveChangesAsync();
        await tx.CommitAsync();
    }
}
