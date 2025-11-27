using System.Collections.Generic;
using System.Threading.Tasks;
using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Web.Services
{
    public interface ILibroService
    {
        Task<IReadOnlyList<LibroDto>> ObtenerLibrosAsync();
        Task<bool> CrearLibroAsync(CrearLibroRequest request);
        Task<bool> ActualizarLibroAsync(int id, ActualizarLibroRequest request);
        Task<bool> EliminarLibroAsync(int id);
    }
}
