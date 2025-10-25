using SGA.Domain.Entities;
using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Mappers;

public static class EjemplarMapper
{
    public static Ejemplar ToEntity(CrearEjemplarRequest r) => new()
    {
        LibroId = r.LibroId
    };

    public static EjemplarDto ToDto(Ejemplar e) => new()
    {
        Id = e.Id,
        LibroId = e.LibroId
    };
}
