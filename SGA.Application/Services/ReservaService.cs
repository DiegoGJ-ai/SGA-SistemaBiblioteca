using SGA.Application.Interfaces;
using SGA.Application.Mappers;
using SGA.Domain.Repository;
using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Services;

public class ReservaService : IReservaService
{
    private readonly IReservaRepository _repo;

    public ReservaService(IReservaRepository repo) => _repo = repo;

    public async Task<IReadOnlyList<ReservaDto>> ListarAsync()
        => (await _repo.ListAsync()).Select(ReservaMapper.ToDto).ToList();

    public async Task<ReservaDto> CrearAsync(CrearReservaRequest request)
    {
        if (request.LibroId <= 0) throw new ArgumentException("LibroId inválido.");

        var entity = ReservaMapper.ToEntity(request);
        await _repo.AddAsync(entity);
        return ReservaMapper.ToDto(entity);
    }
}
