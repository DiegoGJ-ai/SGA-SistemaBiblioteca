using SGA.Domain.Entities;

namespace SGA.Domain.Repository;

public interface ILibroRepository
{
    Task<Libro?> GetByIdAsync(int id);
    Task<IReadOnlyList<Libro>> ListAsync();
    Task AddAsync(Libro entity);
    Task UpdateAsync(Libro entity);
    Task DeleteAsync(int id);

    Task<IReadOnlyList<Libro>> BuscarPorAutorAsync(int autorId);
}
