using SGA.Application.Interfaces;
using System.Threading.Tasks;

namespace SGA.Application.UseCases
{
    public class BuscarLibros
    {
        private readonly ILibroService _libroService;

        public BuscarLibros(ILibroService libroService)
        {
            _libroService = libroService;
        }

        public Task Ejecutar() => _libroService.ListarAsync();
    }
}
