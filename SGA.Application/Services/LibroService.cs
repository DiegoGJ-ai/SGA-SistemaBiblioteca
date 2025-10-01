using SGA.Application.Interfaces;
using SGA.Application.Mappers;
using SGA.Domain.Repository;     // ← IMPORTANTE: usar el namespace de Domain
using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Services;

public class LibroService : ILibroService
{
    private readonly ILibroRepository _repo;

    public LibroService(ILibroRepository repo) => _repo = repo;

    public async Task<IReadOnlyList<LibroDto>> ListarAsync()
    {
        var items = await _repo.ListAsync();
        return items.Select(LibroMapper.ToDto).ToList();
    }

    public async Task<LibroDto> CrearAsync(CrearLibroRequest request)
    {
        var entity = LibroMapper.ToEntity(request);
        await _repo.AddAsync(entity);
        var created = await _repo.GetByIdAsync(entity.Id) ?? entity;
        return LibroMapper.ToDto(created);
    }
}
