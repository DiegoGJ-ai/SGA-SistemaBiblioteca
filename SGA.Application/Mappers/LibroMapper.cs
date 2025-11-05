using SGA.Domain.Entities;
using SGA.Model.Dtos;

namespace SGA.Application
{
    public static class LibroMapper
    {
        public static LibroDto ToDto(this Libro entity)
        {
            return new LibroDto
            {
                Id = entity.Id,
                Titulo = entity.Titulo,
                AutorId = entity.AutorId
            };
        }

        public static IEnumerable<LibroDto> ToDtoList(this IEnumerable<Libro> entities)
        {
            return entities.Select(e => e.ToDto());
        }
    }
}
