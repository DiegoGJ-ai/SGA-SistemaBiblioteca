using Microsoft.AspNetCore.Mvc;
using SGA.Application.Interfaces;
using SGA.Model.Dtos;
using SGA.Model.Requests;
using SGA.Model.Responses;

namespace SGA.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    private readonly ILibroService _service;
    public LibrosController(ILibroService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IReadOnlyList<LibroDto>>>> Get()
    {
        var data = await _service.ListarAsync();
        return Ok(ApiResponse<IReadOnlyList<LibroDto>>.Ok(data));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<LibroDto>>> Post([FromBody] CrearLibroRequest request)
    {
        var dto = await _service.CrearAsync(request);
        return Ok(ApiResponse<LibroDto>.Ok(dto, "Libro creado"));
    }
}
