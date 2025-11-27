using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using SGA.Model.Dtos;
using SGA.Model.Requests;
using SGA.Model.Responses;
using SGA.Web.Clients;
using SGA.Web.Services;

namespace SGA.Web.Tests
{
    public class LibroServiceTests
    {
        private readonly Mock<ILibroApiClient> _libroApiClientMock;
        private readonly LibroService _sut;

        public LibroServiceTests()
        {
            _libroApiClientMock = new Mock<ILibroApiClient>();
            _sut = new LibroService(_libroApiClientMock.Object);
        }

        [Fact]
        public async Task ObtenerLibrosAsync_devuelve_lista_cuando_la_api_responde_ok()
        {
            
            var libros = new List<LibroDto>
            {
                new LibroDto { Id = 1, Titulo = "Libro 1", AutorId = 1 },
                new LibroDto { Id = 2, Titulo = "Libro 2", AutorId = 2 }
            };

            _libroApiClientMock
                .Setup(c => c.GetLibrosAsync())
                .ReturnsAsync(ApiResponse<IReadOnlyList<LibroDto>>.Ok(libros));

            
            var result = await _sut.ObtenerLibrosAsync();

            
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task CrearLibroAsync_devuelve_true_cuando_la_api_responde_ok()
        {
            // Arrange
            var request = new CrearLibroRequest
            {
                Titulo = "Nuevo libro",
                AutorId = 1
            };

            _libroApiClientMock
                .Setup(c => c.CrearLibroAsync(request))
                .ReturnsAsync(ApiResponse.Ok("Creado"));

            // Act
            var ok = await _sut.CrearLibroAsync(request);

            // Assert
            Assert.True(ok);
        }

        [Fact]
        public async Task CrearLibroAsync_devuelve_false_cuando_la_api_falla()
        {
            // Arrange
            var request = new CrearLibroRequest
            {
                Titulo = "Nuevo libro",
                AutorId = 1
            };

            _libroApiClientMock
                .Setup(c => c.CrearLibroAsync(request))
                .ReturnsAsync(ApiResponse.Fail("Error"));

            // Act
            var ok = await _sut.CrearLibroAsync(request);

            // Assert
            Assert.False(ok);
        }
    }
}
