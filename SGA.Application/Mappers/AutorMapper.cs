using SGA.Domain.Entities;
using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Mappers;

public static class AutorMapper
{
    public static Autor ToEntity(CrearAutorRequest r) => new()
    {
        Nombre = r.Nombre
    };

    public static AutorDto ToDto(Autor e) => new()
    {
        Id = e.Id,
        Nombre = e.Nombre
    };
}
