using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Interfaces;

public interface IAutorService
{
    Task<IReadOnlyList<AutorDto>> ListarAsync();
    Task<AutorDto?> BuscarPorIdAsync(int id);
    Task<AutorDto> CrearAsync(CrearAutorRequest request);
    Task ActualizarAsync(int id, ActualizarAutorRequest request);
    Task EliminarAsync(int id);
}
