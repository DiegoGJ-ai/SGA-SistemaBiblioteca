using SGA.Domain.Entities;

namespace SGA.Domain.Repository;

public interface IReservaRepository
{
    Task CrearReservaAsync(int libroId);
    Task<Reserva?> SiguienteReservaAsync(int libroId);
}
