using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Web.Services
{
    public interface ILibroApiClient
    {
        Task<IReadOnlyList<LibroDto>> GetAllAsync();
        Task<LibroDto?> GetByIdAsync(int id);
        Task<LibroDto> CreateAsync(CrearLibroRequest request);
        Task UpdateAsync(int id, CrearLibroRequest request);
        Task DeleteAsync(int id);
    }
}
