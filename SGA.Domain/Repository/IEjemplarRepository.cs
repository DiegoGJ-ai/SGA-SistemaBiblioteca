using SGA.Domain.Entities;

namespace SGA.Domain.Repository;

public interface IEjemplarRepository
{
    Task<Ejemplar?> GetDisponiblePorLibroAsync(int libroId);
}
