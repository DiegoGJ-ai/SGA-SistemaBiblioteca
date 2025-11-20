using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Interfaces
{
    public interface ILibroService
    {
        Task<IReadOnlyList<LibroDto>> ListarAsync();
        Task<LibroDto?> BuscarPorIdAsync(int id);
        Task<LibroDto> CrearAsync(CrearLibroRequest request);
        Task ActualizarAsync(int id, CrearLibroRequest request);
        Task EliminarAsync(int id);
    }
}
