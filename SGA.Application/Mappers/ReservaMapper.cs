using SGA.Domain.Entities;
using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Mappers;

public static class ReservaMapper
{
    public static Reserva ToEntity(CrearReservaRequest r) => new()
    {
        LibroId = r.LibroId,
        Fecha = DateTime.UtcNow
    };

    public static ReservaDto ToDto(Reserva e) => new()
    {
        Id = e.Id,
        LibroId = e.LibroId,
        Fecha = e.Fecha
    };
}
