using SGA.Domain.Entities;
using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Mappers;

public static class PrestamoMapper
{
    public static Prestamo ToEntity(CrearPrestamoRequest r) => new()
    {
        EjemplarId = r.EjemplarId,
        Fecha = DateTime.UtcNow,
        Vence = DateTime.UtcNow.AddDays(r.Dias > 0 ? r.Dias : 7)
    };

    public static PrestamoDto ToDto(Prestamo e) => new()
    {
        Id = e.Id,
        EjemplarId = e.EjemplarId,
        Fecha = e.Fecha,
        Vence = e.Vence
    };
}
