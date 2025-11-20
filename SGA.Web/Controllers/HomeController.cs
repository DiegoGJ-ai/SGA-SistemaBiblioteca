using Microsoft.AspNetCore.Mvc;
using SGA.Model.Dtos;
using SGA.Model.Requests;
using SGA.Web.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGA.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibroApiClient _libroApiClient;

        public HomeController(LibroApiClient libroApiClient)
        {
            _libroApiClient = libroApiClient;
        }

        // ------------------ LISTAR ------------------

        public async Task<IActionResult> Index()
        {
            try
            {
                IReadOnlyList<LibroDto> libros = await _libroApiClient.GetLibrosAsync();
                return View(libros);
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View(Array.Empty<LibroDto>());
            }
        }

        // ------------------ CREAR ------------------

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CrearLibroRequest());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CrearLibroRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _libroApiClient.CrearLibroAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        // ------------------ EDITAR ------------------

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var libro = await _libroApiClient.GetLibroAsync(id);
                if (libro == null)
                {
                    return NotFound();
                }

                var vm = new CrearLibroRequest
                {
                    Titulo = libro.Titulo,
                    AutorId = libro.AutorId
                };

                ViewBag.LibroId = libro.Id;
                return View(vm);
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CrearLibroRequest model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.LibroId = id;
                return View(model);
            }

            try
            {
                await _libroApiClient.ActualizarLibroAsync(id, model);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.LibroId = id;
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        // ------------------ ELIMINAR ------------------

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var libro = await _libroApiClient.GetLibroAsync(id);
                if (libro == null)
                {
                    return NotFound();
                }

                return View(libro);
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _libroApiClient.EliminarLibroAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
