using SGA.Domain.Entities;

namespace SGA.Domain.Repository
{
    public interface ILibroRepository
    {
        Task<Libro?> GetByIdAsync(int id);
        Task<IReadOnlyList<Libro>> ListAsync();
        Task AddAsync(Libro entity);
    }
}
