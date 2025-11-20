using Microsoft.AspNetCore.Mvc;
using SGA.Application.Interfaces;
using SGA.Model.Dtos;
using SGA.Model.Requests;
using SGA.Model.Responses;

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

        // GET api/libros
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IReadOnlyList<LibroDto>>>> Get()
        {
            var data = await _service.ListarAsync();

            var response = ApiResponse<IReadOnlyList<LibroDto>>.Ok(data);
            return Ok(response);
        }

        // GET api/libros/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ApiResponse<LibroDto>>> GetById(int id)
        {
            var dto = await _service.BuscarPorIdAsync(id);

            if (dto == null)
            {
                return NotFound(ApiResponse<LibroDto>.Fail("Libro no encontrado"));
            }

            return Ok(ApiResponse<LibroDto>.Ok(dto));
        }

        // POST api/libros
        [HttpPost]
        public async Task<ActionResult<ApiResponse<LibroDto>>> Post([FromBody] CrearLibroRequest request)
        {
            var dto = await _service.CrearAsync(request);

            var response = ApiResponse<LibroDto>.Ok(dto, "Libro creado correctamente");

            // 201 Created con Location
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, response);
        }

        // PUT api/libros/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse<object>>> Put(int id, [FromBody] CrearLibroRequest request)
        {
            await _service.ActualizarAsync(id, request);

            return Ok(ApiResponse<object>.Ok(null, "Libro actualizado correctamente"));
        }

        // DELETE api/libros/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(int id)
        {
            await _service.EliminarAsync(id);

            return Ok(ApiResponse<object>.Ok(null, "Libro eliminado correctamente"));
        }
    }
}
