using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Interfaces;

public interface IEjemplarService
{
    Task<IReadOnlyList<EjemplarDto>> ListarAsync();
    Task<EjemplarDto> CrearAsync(CrearEjemplarRequest request);
}
