using SGA.Model.Dtos;
using SGA.Model.Requests;
using SGA.Model.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SGA.Web.Services
{
    public class LibroApiClient
    {
        private readonly HttpClient _httpClient;

        public LibroApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // ------------------ Métodos privados de ayuda ------------------

        private static async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"Error HTTP {(int)response.StatusCode}: {json}");
            }

            var apiResponse = System.Text.Json.JsonSerializer.Deserialize<ApiResponse<T>>(
                json,
                new System.Text.Json.JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (apiResponse == null)
            {
                throw new HttpRequestException("No se pudo deserializar la respuesta de la API.");
            }

            if (!apiResponse.Success)
            {
                throw new HttpRequestException(apiResponse.Message ?? "Error en la API.");
            }

            return apiResponse.Data!;
        }

        // ------------------ CRUD Libros ------------------

        public async Task<IReadOnlyList<LibroDto>> GetLibrosAsync()
        {
            var response = await _httpClient.GetAsync("api/Libros");
            return await HandleResponse<IReadOnlyList<LibroDto>>(response);
        }

        public async Task<LibroDto?> GetLibroAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Libros/{id}");
            return await HandleResponse<LibroDto?>(response);
        }

        public async Task<LibroDto> CrearLibroAsync(CrearLibroRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Libros", request);
            return await HandleResponse<LibroDto>(response);
        }

        public async Task<LibroDto> ActualizarLibroAsync(int id, CrearLibroRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Libros/{id}", request);
            return await HandleResponse<LibroDto>(response);
        }

        public async Task EliminarLibroAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Libros/{id}");
            await HandleResponse<bool>(response);
        }
    }
}
