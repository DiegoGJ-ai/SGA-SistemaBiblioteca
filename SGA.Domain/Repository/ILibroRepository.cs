using SGA.Domain.Entities;

namespace SGA.Domain.Repository
{
    public interface ILibroRepository
    {
        Task AddAsync(Libro libro);
        Task DeleteAsync(int id);
        Task<Libro?> GetByIdAsync(int id);
        Task<IReadOnlyList<Libro>> ListAsync(); 
        Task UpdateAsync(Libro libro);
        Task<IReadOnlyList<Libro>> BuscarPorAutorAsync(int autorId); 
    }
}
