using SGA.Domain.Entities;

namespace SGA.Domain.Repository;

public interface IAutorRepository
{
    Task<Autor?> GetByIdAsync(int id);
    Task<IReadOnlyList<Autor>> ListAsync();
    Task AddAsync(Autor entity);
    Task UpdateAsync(Autor entity);
    Task DeleteAsync(int id);
}
