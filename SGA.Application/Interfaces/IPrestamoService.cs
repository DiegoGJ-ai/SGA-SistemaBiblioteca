using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Interfaces;

public interface IPrestamoService
{
    Task<IReadOnlyList<PrestamoDto>> ListarAsync();
    Task<IReadOnlyList<PrestamoDto>> ListarVigentesAsync();
    Task<PrestamoDto> CrearAsync(CrearPrestamoRequest request);
    Task MarcarDevueltoAsync(int prestamoId);
}
