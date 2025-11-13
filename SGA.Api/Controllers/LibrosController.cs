using Microsoft.AspNetCore.Mvc;
using SGA.Application.Interfaces;
using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _service;

        public LibrosController(ILibroService service)
        {
            _service = service;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var libros = await _service.ListarAsync();
            return Ok(libros);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var libro = await _service.BuscarPorIdAsync(id);
            if (libro == null)
                return NotFound($"El libro con ID {id} no existe");

            return Ok(libro);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearLibroRequest request)
        {
            var libroCreado = await _service.CrearAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = libroCreado.Id }, libroCreado);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CrearLibroRequest request)
        {
            await _service.ActualizarAsync(id, request);
            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarAsync(id);
            return NoContent();
        }
    }
}
