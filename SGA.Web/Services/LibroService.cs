using System.Collections.Generic;
using System.Threading.Tasks;
using SGA.Model.Dtos;
using SGA.Model.Requests;
using SGA.Web.Clients;

namespace SGA.Web.Services
{

    public class LibroService : ILibroService
    {
        private readonly ILibroApiClient _client;

        public LibroService(ILibroApiClient client)
        {
            _client = client;
        }

        public async Task<IReadOnlyList<LibroDto>> ObtenerLibrosAsync()
        {
            var response = await _client.GetLibrosAsync();

            return response.Success && response.Data != null
                ? response.Data
                : new List<LibroDto>();
        }

        public async Task<bool> CrearLibroAsync(CrearLibroRequest request)
        {
            var response = await _client.CrearLibroAsync(request);
            return response.Success;
        }

        public async Task<bool> ActualizarLibroAsync(int id, ActualizarLibroRequest request)
        {
            var response = await _client.ActualizarLibroAsync(id, request);
            return response.Success;
        }

        public async Task<bool> EliminarLibroAsync(int id)
        {
            var response = await _client.EliminarLibroAsync(id);
            return response.Success;
        }
    }
}
