using SGA.Domain.Entities;

namespace SGA.Domain.Repository;

public interface IPrestamoRepository
{
    Task<Prestamo?> GetByIdAsync(int id);
    Task<IReadOnlyList<Prestamo>> ListPendientesAsync();
    Task<Prestamo> CrearPrestamoAsync(int ejemplarId, DateTime vence);
    Task MarcarDevolucionAsync(int prestamoId);
}
