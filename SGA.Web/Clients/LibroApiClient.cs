using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SGA.Model.Dtos;
using SGA.Model.Requests;
using SGA.Model.Responses;

namespace SGA.Web.Clients
{
    public class LibroApiClient : ILibroApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public LibroApiClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"] ?? "https://localhost:7149";
        }

        private string BuildUrl(string relative)
            => $"{_baseUrl.TrimEnd('/')}/{relative.TrimStart('/')}";

        public async Task<ApiResponse<IReadOnlyList<LibroDto>>> GetLibrosAsync()
        {
            var httpResponse = await _httpClient.GetAsync(BuildUrl("api/Libros"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                return ApiResponse<IReadOnlyList<LibroDto>>
                    .Fail("Error al obtener la lista de libros.");
            }

            var content = await httpResponse.Content
                .ReadFromJsonAsync<ApiResponse<IReadOnlyList<LibroDto>>>();

            return content ?? ApiResponse<IReadOnlyList<LibroDto>>
                .Fail("La API devolvió una respuesta vacía al listar libros.");
        }

        public async Task<ApiResponse<LibroDto>> GetLibroByIdAsync(int id)
        {
            var httpResponse = await _httpClient.GetAsync(BuildUrl($"api/Libros/{id}"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                return ApiResponse<LibroDto>.Fail("Error al obtener el libro.");
            }

            var content = await httpResponse.Content
                .ReadFromJsonAsync<ApiResponse<LibroDto>>();

            return content ?? ApiResponse<LibroDto>
                .Fail("La API devolvió una respuesta vacía al obtener el libro.");
        }

        public async Task<ApiResponse> CrearLibroAsync(CrearLibroRequest request)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(BuildUrl("api/Libros"), request);

            if (!httpResponse.IsSuccessStatusCode)
            {
                return ApiResponse.Fail("Error al crear el libro.");
            }

            var content = await httpResponse.Content
                .ReadFromJsonAsync<ApiResponse>();

            return content ?? ApiResponse.Fail("La API devolvió una respuesta vacía al crear el libro.");
        }

        public async Task<ApiResponse> ActualizarLibroAsync(int id, ActualizarLibroRequest request)
        {
            var httpResponse = await _httpClient.PutAsJsonAsync(BuildUrl($"api/Libros/{id}"), request);

            if (!httpResponse.IsSuccessStatusCode)
            {
                return ApiResponse.Fail("Error al actualizar el libro.");
            }

            var content = await httpResponse.Content
                .ReadFromJsonAsync<ApiResponse>();

            return content ?? ApiResponse.Fail("La API devolvió una respuesta vacía al actualizar el libro.");
        }

        public async Task<ApiResponse> EliminarLibroAsync(int id)
        {
            var httpResponse = await _httpClient.DeleteAsync(BuildUrl($"api/Libros/{id}"));

            if (!httpResponse.IsSuccessStatusCode)
            {
                return ApiResponse.Fail("Error al eliminar el libro.");
            }

            var content = await httpResponse.Content
                .ReadFromJsonAsync<ApiResponse>();

            return content ?? ApiResponse.Fail("La API devolvió una respuesta vacía al eliminar el libro.");
        }
    }
}
