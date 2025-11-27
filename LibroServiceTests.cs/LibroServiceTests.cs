using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using SGA.Model.Dtos;
using SGA.Model.Requests;
using SGA.Model.Responses;
using SGA.Web.Services;
using Xunit;

namespace SGA.Web.Tests.Services
{
    public class LibroServiceTests
    {
        private readonly Mock<ILibroApiClient> _libroApiClientMock;
        private readonly LibroService _sut; // System Under Test

        public LibroServiceTests()
        {
            _libroApiClientMock = new Mock<ILibroApiClient>(MockBehavior.Strict);
            _sut = new LibroService(_libroApiClientMock.Object);
        }

        #region Listar / Obtener

        [Fact]
        public async Task ObtenerLibrosAsync_devuelve_lista_desde_la_api()
        {
            // Arrange
            var libros = new List<LibroDto>
            {
                new LibroDto { Id = 1, Titulo = "Prueba", AutorId = 1 }
            };

            var apiResponse = new ApiResponse<IReadOnlyList<LibroDto>>
            {
                Success = true,
                Data = libros
            };

            _libroApiClientMock
                .Setup(x => x.GetLibrosAsync())
                .ReturnsAsync(apiResponse);

            // Act
            var resultado = await _sut.ObtenerLibrosAsync();

            // Assert
            Assert.Single(resultado);
            Assert.Equal("Prueba", resultado.First().Titulo);

            _libroApiClientMock.Verify(x => x.GetLibrosAsync(), Times.Once);
        }

        [Fact]
        public async Task ObtenerLibrosAsync_devuelve_lista_vacia_si_la_api_regresa_null_o_error()
        {
            // Arrange: respuesta nula
            _libroApiClientMock
                .Setup(x => x.GetLibrosAsync())
                .ReturnsAsync((ApiResponse<IReadOnlyList<LibroDto>>?)null);

            // Act
            var resultado = await _sut.ObtenerLibrosAsync();

            // Assert
            Assert.Empty(resultado);
        }

        [Fact]
        public async Task ObtenerPorIdAsync_lanza_excepcion_si_id_es_menor_o_igual_a_cero()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                () => _sut.ObtenerPorIdAsync(0));
        }

        [Fact]
        public async Task ObtenerPorIdAsync_devuelve_libro_si_la_api_responde_ok()
        {
            // Arrange
            var libro = new LibroDto { Id = 10, Titulo = "Libro 10", AutorId = 2 };

            var apiResponse = new ApiResponse<LibroDto>
            {
                Success = true,
                Data = libro
            };

            _libroApiClientMock
                .Setup(x => x.GetLibroByIdAsync(10))
                .ReturnsAsync(apiResponse);

            // Act
            var resultado = await _sut.ObtenerPorIdAsync(10);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(10, resultado!.Id);
            Assert.Equal("Libro 10", resultado.Titulo);
        }

        [Fact]
        public async Task ObtenerPorIdAsync_devuelve_null_si_la_api_regresa_error()
        {
            // Arrange
            var apiResponse = new ApiResponse<LibroDto>
            {
                Success = false,
                Data = null,
                Message = "Error"
            };

            _libroApiClientMock
                .Setup(x => x.GetLibroByIdAsync(99))
                .ReturnsAsync(apiResponse);

            // Act
            var resultado = await _sut.ObtenerPorIdAsync(99);

            // Assert
            Assert.Null(resultado);
        }

        #endregion

        #region Crear

        [Fact]
        public async Task CrearAsync_lanza_ArgumentNullException_si_request_es_null()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => _sut.CrearAsync(null!));
        }

        [Fact]
        public async Task CrearAsync_devuelve_true_cuando_la_api_responde_success()
        {
            // Arrange
            var request = new CrearLibroRequest
            {
                Titulo = "Nuevo libro",
                AutorId = 1
            };

            var apiResponse = new ApiResponse<LibroDto>
            {
                Success = true,
                Data = new LibroDto { Id = 5, Titulo = "Nuevo libro", AutorId = 1 }
            };

            _libroApiClientMock
                .Setup(x => x.CrearLibroAsync(request))
                .ReturnsAsync(apiResponse);

            // Act
            var resultado = await _sut.CrearAsync(request);

            // Assert
            Assert.True(resultado);

            _libroApiClientMock.Verify(
                x => x.CrearLibroAsync(request),
                Times.Once);
        }

        [Fact]
        public async Task CrearAsync_devuelve_false_cuando_la_api_responde_error()
        {
            // Arrange
            var request = new CrearLibroRequest
            {
                Titulo = "Falla",
                AutorId = 1
            };

            var apiResponse = new ApiResponse<LibroDto>
            {
                Success = false,
                Message = "Error de API"
            };

            _libroApiClientMock
                .Setup(x => x.CrearLibroAsync(request))
                .ReturnsAsync(apiResponse);

            // Act
            var resultado = await _sut.CrearAsync(request);

            // Assert
            Assert.False(resultado);
        }

        #endregion

        #region Actualizar

        [Fact]
        public async Task ActualizarAsync_lanza_excepcion_si_id_es_invalido()
        {
            var request = new ActualizarLibroRequest
            {
                Titulo = "Editado",
                AutorId = 1
            };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                () => _sut.ActualizarAsync(0, request));
        }

        [Fact]
        public async Task ActualizarAsync_lanza_excepcion_si_request_es_null()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => _sut.ActualizarAsync(1, null!));
        }

        [Fact]
        public async Task ActualizarAsync_devuelve_true_cuando_la_api_responde_success()
        {
            // Arrange
            var request = new ActualizarLibroRequest
            {
                Titulo = "Editado",
                AutorId = 1
            };

            var apiResponse = new ApiResponse<LibroDto>
            {
                Success = true,
                Data = new LibroDto { Id = 1, Titulo = "Editado", AutorId = 1 }
            };

            _libroApiClientMock
                .Setup(x => x.ActualizarLibroAsync(1, request))
                .ReturnsAsync(apiResponse);

            // Act
            var resultado = await _sut.ActualizarAsync(1, request);

            // Assert
            Assert.True(resultado);

            _libroApiClientMock.Verify(
                x => x.ActualizarLibroAsync(1, request),
                Times.Once);
        }

        #endregion

        #region Eliminar

        [Fact]
        public async Task EliminarAsync_lanza_excepcion_si_id_es_invalido()
        {
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                () => _sut.EliminarAsync(0));
        }

        [Fact]
        public async Task EliminarAsync_devuelve_true_cuando_la_api_responde_success()
        {
            // Arrange
            var apiResponse = new ApiResponse<bool>
            {
                Success = true,
                Data = true
            };

            _libroApiClientMock
                .Setup(x => x.EliminarLibroAsync(10))
                .ReturnsAsync(apiResponse);

            // Act
            var resultado = await _sut.EliminarAsync(10);

            // Assert
            Assert.True(resultado);

            _libroApiClientMock.Verify(
                x => x.EliminarLibroAsync(10),
                Times.Once);
        }

        #endregion
    }
}
