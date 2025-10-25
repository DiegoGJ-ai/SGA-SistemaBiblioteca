using Microsoft.AspNetCore.Mvc;
using SGA.Application.Interfaces;
using SGA.Model.Requests;

namespace SGA.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EjemplaresController : ControllerBase
{
    private readonly IEjemplarService _service;

    public EjemplaresController(IEjemplarService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.ListarAsync());

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CrearEjemplarRequest request)
        => Ok(await _service.CrearAsync(request));
}
