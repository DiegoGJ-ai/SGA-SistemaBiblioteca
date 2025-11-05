using Microsoft.EntityFrameworkCore;
using SGA.Domain.Entities;
using SGA.Persistence.Context;
using SGA.Persistence.Repositories;
using Xunit;

namespace SGA.Persistence.Test
{
    public class LibroRepositoryTests
    {
        private LibraryContext GetContext()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) 
                .Options;

            return new LibraryContext(options);
        }

        [Fact]
        public async Task AddAsync_DeberiaAgregarUnLibro()
        {
            // Arrange
            var context = GetContext();
            var repo = new LibroRepository(context);
            var libro = new Libro { Titulo = "Cien años de soledad", AutorId = 1 };

            // Act
            await repo.AddAsync(libro);
            var resultado = await repo.GetByIdAsync(libro.Id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("Cien años de soledad", resultado!.Titulo);
        }

        [Fact]
        public async Task DeleteAsync_DeberiaEliminarUnLibro()
        {
            // Arrange
            var context = GetContext();
            var repo = new LibroRepository(context);
            var libro = new Libro { Titulo = "Libro temporal", AutorId = 1 };

            await repo.AddAsync(libro);

            // Act
            await repo.DeleteAsync(libro.Id);
            var resultado = await repo.GetByIdAsync(libro.Id);

            // Assert
            Assert.Null(resultado);
        }

        [Fact]
        public async Task ListAsync_DeberiaRetornarListaDeLibros()
        {
            // Arrange
            var context = GetContext();
            var repo = new LibroRepository(context);
            await repo.AddAsync(new Libro { Titulo = "Libro 1", AutorId = 1 });
            await repo.AddAsync(new Libro { Titulo = "Libro 2", AutorId = 1 });

            // Act
            var lista = await repo.ListAsync();

            // Assert
            Assert.NotEmpty(lista);
            Assert.Equal(2, lista.Count());
        }
    }
}
