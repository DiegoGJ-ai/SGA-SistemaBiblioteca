using System.Collections.Generic;
using System.Threading.Tasks;
using SGA.Model.Dtos;
using SGA.Model.Requests;
using SGA.Model.Responses;

namespace SGA.Web.Clients
{
    public interface ILibroApiClient
    {
        Task<ApiResponse<IReadOnlyList<LibroDto>>> GetLibrosAsync();
        Task<ApiResponse<LibroDto>> GetLibroByIdAsync(int id);
        Task<ApiResponse> CrearLibroAsync(CrearLibroRequest request);
        Task<ApiResponse> ActualizarLibroAsync(int id, ActualizarLibroRequest request);
        Task<ApiResponse> EliminarLibroAsync(int id);
    }
}
