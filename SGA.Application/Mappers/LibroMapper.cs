using SGA.Domain.Entities;
using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Mappers;

public static class LibroMapper
{
    public static LibroDto ToDto(Libro e) => new()
    {
        Id = e.Id,
        Titulo = e.Titulo,
        Autor = e.Autor?.Nombre ?? string.Empty
    };

    public static Libro ToEntity(CrearLibroRequest r) => new()
    {
        Titulo = r.Titulo,
        AutorId = r.AutorId
    };
}
