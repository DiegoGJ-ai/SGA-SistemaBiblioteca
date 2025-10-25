using Microsoft.AspNetCore.Mvc;
using SGA.Application.Interfaces;
using SGA.Model.Requests;

namespace SGA.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutoresController : ControllerBase
{
    private readonly IAutorService _service;

    public AutoresController(IAutorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.ListarAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var autor = await _service.BuscarPorIdAsync(id);
        return autor is null ? NotFound() : Ok(autor);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CrearAutorRequest request)
    {
        var autor = await _service.CrearAsync(request);
        return Ok(autor);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] ActualizarAutorRequest request)
    {
        await _service.ActualizarAsync(id, request);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.EliminarAsync(id);
        return NoContent();
    }
}
