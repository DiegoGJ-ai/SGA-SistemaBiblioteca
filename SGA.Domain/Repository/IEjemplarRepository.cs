using SGA.Domain.Entities;

namespace SGA.Domain.Repository;

public interface IEjemplarRepository : IRepositoryBase<Ejemplar>
{
    Task<Ejemplar?> GetDisponiblePorLibroAsync(int libroId);
}
