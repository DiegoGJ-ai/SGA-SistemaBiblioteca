using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Interfaces
{
    public interface ILibroService
    {
        Task<LibroDto> CrearAsync(CrearLibroRequest request);
        Task<IEnumerable<LibroDto>> ListarAsync();
        Task<LibroDto?> BuscarPorIdAsync(int id);
        Task EliminarAsync(int id);
        Task ActualizarAsync(int id, CrearLibroRequest request);
    }
}
