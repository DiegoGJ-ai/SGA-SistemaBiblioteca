using Moq;
using SGA.Application.Services;
using SGA.Domain.Entities;
using SGA.Domain.Repository;
using SGA.Model.Requests;
using Xunit;

namespace SGA.Application.Test
{
    public class LibroServiceTests
    {
        [Fact]
        public async Task CrearAsync_DeberiaCrearLibroCorrectamente()
        {
            // Arrange
            var mockRepo = new Mock<ILibroRepository>();
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Libro>()))
                    .Returns(Task.CompletedTask);

            var service = new LibroService(mockRepo.Object);
            var request = new CrearLibroRequest
            {
                Titulo = "El Principito",
                AutorId = 1
            };

            // Act
            var resultado = await service.CrearAsync(request);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal("El Principito", resultado.Titulo);
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Libro>()), Times.Once);
        }

        [Fact]
        public async Task CrearAsync_DeberiaLanzarExcepcionSiTituloEsVacio()
        {
            // Arrange
            var mockRepo = new Mock<ILibroRepository>();
            var service = new LibroService(mockRepo.Object);
            var request = new CrearLibroRequest
            {
                Titulo = "",
                AutorId = 1
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => service.CrearAsync(request));
        }
    }
}
