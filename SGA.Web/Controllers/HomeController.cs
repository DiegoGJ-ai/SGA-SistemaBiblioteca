using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SGA.Model.Dtos;
using SGA.Model.Requests;
using SGA.Web.Services;

namespace SGA.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILibroService _libroService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILibroService libroService, ILogger<HomeController> logger)
        {
            _libroService = libroService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var libros = await _libroService.ObtenerLibrosAsync();
            return View(libros);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CrearLibroRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CrearLibroRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var ok = await _libroService.CrearLibroAsync(request);

            if (!ok)
            {
                ModelState.AddModelError(string.Empty, "No se pudo crear el libro.");
                return View(request);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var libros = await _libroService.ObtenerLibrosAsync();
            var libro = libros.FirstOrDefault(l => l.Id == id);

            if (libro is null)
                return NotFound();

            var model = new ActualizarLibroRequest
            {
                Titulo = libro.Titulo,
                AutorId = libro.AutorId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ActualizarLibroRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var ok = await _libroService.ActualizarLibroAsync(id, request);

            if (!ok)
            {
                ModelState.AddModelError(string.Empty, "No se pudo actualizar el libro.");
                return View(request);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _libroService.EliminarLibroAsync(id);

            if (!ok)
            {
                // Podrías mostrar una vista de error, pero para simplificar:
                return BadRequest("No se pudo eliminar el libro.");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
