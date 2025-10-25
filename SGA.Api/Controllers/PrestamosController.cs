using Microsoft.AspNetCore.Mvc;
using SGA.Application.Interfaces;
using SGA.Model.Requests;

namespace SGA.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrestamosController : ControllerBase
{
    private readonly IPrestamoService _service;

    public PrestamosController(IPrestamoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.ListarAsync());

    [HttpGet("vigentes")]
    public async Task<IActionResult> GetVigentes()
        => Ok(await _service.ListarVigentesAsync());

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CrearPrestamoRequest request)
        => Ok(await _service.CrearAsync(request));

    [HttpPut("{id:int}/devolver")]
    public async Task<IActionResult> Devolver(int id)
    {
        await _service.MarcarDevueltoAsync(id);
        return Ok(new { message = "Préstamo devuelto correctamente" });
    }
}
