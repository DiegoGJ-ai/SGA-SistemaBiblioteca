using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Interfaces;

public interface IReservaService
{
    Task<IReadOnlyList<ReservaDto>> ListarAsync();
    Task<ReservaDto> CrearAsync(CrearReservaRequest request);
}
