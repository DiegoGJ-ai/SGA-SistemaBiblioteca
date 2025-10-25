using SGA.Application.Interfaces;
using SGA.Application.Mappers;
using SGA.Domain.Repository;
using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Services;

public class PrestamoService : IPrestamoService
{
    private readonly IPrestamoRepository _repo;

    public PrestamoService(IPrestamoRepository repo) => _repo = repo;

    public async Task<IReadOnlyList<PrestamoDto>> ListarAsync()
        => (await _repo.ListAsync()).Select(PrestamoMapper.ToDto).ToList();

    public async Task<IReadOnlyList<PrestamoDto>> ListarVigentesAsync()
        => (await _repo.ListAsync())
            .Where(p => p.Vence >= DateTime.UtcNow.Date)
            .Select(PrestamoMapper.ToDto)
            .ToList();

    public async Task<PrestamoDto> CrearAsync(CrearPrestamoRequest request)
    {
        if (request.EjemplarId <= 0) throw new ArgumentException("EjemplarId inválido.");
        if (request.Dias <= 0) throw new ArgumentException("Días inválidos.");

        var entity = PrestamoMapper.ToEntity(request);
        await _repo.AddAsync(entity);
        var e = await _repo.GetByIdAsync(entity.Id) ?? entity;
        return PrestamoMapper.ToDto(e);
    }

    public async Task MarcarDevueltoAsync(int prestamoId)
    {
        var e = await _repo.GetByIdAsync(prestamoId)
                ?? throw new InvalidOperationException("Préstamo no encontrado.");
        // Regla simple para cierre:
        e.Vence = DateTime.UtcNow;
        await _repo.UpdateAsync(e);
    }
}
