using SGA.Application.Interfaces;
using SGA.Application.Mappers;
using SGA.Domain.Repository;
using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Services;

public class AutorService : IAutorService
{
    private readonly IAutorRepository _repo;

    public AutorService(IAutorRepository repo) => _repo = repo;

    public async Task<IReadOnlyList<AutorDto>> ListarAsync()
        => (await _repo.ListAsync()).Select(AutorMapper.ToDto).ToList();

    public async Task<AutorDto?> BuscarPorIdAsync(int id)
    {
        var e = await _repo.GetByIdAsync(id);
        return e is null ? null : AutorMapper.ToDto(e);
    }

    public async Task<AutorDto> CrearAsync(CrearAutorRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Nombre))
            throw new ArgumentException("El nombre del autor es obligatorio.");

        var entity = AutorMapper.ToEntity(request);
        await _repo.AddAsync(entity);
        return AutorMapper.ToDto(entity);
    }

    public async Task ActualizarAsync(int id, ActualizarAutorRequest request)
    {
        var e = await _repo.GetByIdAsync(id)
                ?? throw new InvalidOperationException("Autor no encontrado.");

        if (!string.IsNullOrWhiteSpace(request.Nombre))
            e.Nombre = request.Nombre!;

        await _repo.UpdateAsync(e);
    }

    public async Task EliminarAsync(int id) => await _repo.DeleteAsync(id);
}
