using Microsoft.AspNetCore.Mvc;
using SGA.Domain.Repository;

namespace SGA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroRepository _repo;
        public LibrosController(ILibroRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _repo.ListAsync());
    }
}
