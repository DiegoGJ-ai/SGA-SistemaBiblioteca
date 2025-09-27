using SGA.Application.Interfaces;
using SGA.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGA.Application.Services
{
    public class LibroService : ILibroService
    {
        public Task<IReadOnlyList<Libro>> ListarAsync()
        {
            // Ejemplo simple, luego se conecta con Persistence
            var libros = new List<Libro>
            {
                new Libro { Id = 1, Titulo = "Cien años de soledad", Autor = "García Márquez" },
                new Libro { Id = 2, Titulo = "Don Quijote de la Mancha", Autor = "Cervantes" }
            };

            return Task.FromResult<IReadOnlyList<Libro>>(libros);
        }
    }
}
