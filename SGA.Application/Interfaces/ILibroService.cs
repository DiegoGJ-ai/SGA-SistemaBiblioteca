using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Interfaces;

public interface ILibroService
{
    Task<IReadOnlyList<LibroDto>> ListarAsync();
    Task<LibroDto> CrearAsync(CrearLibroRequest request);
}
