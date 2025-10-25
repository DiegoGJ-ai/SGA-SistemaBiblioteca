namespace SGA.Domain.Repository;

public interface IRepositoryBase<T> where T : class
{
    Task<IReadOnlyList<T>> ListAsync();
    Task<T?> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
