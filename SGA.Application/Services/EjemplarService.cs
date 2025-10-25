using SGA.Application.Interfaces;
using SGA.Application.Mappers;
using SGA.Domain.Repository;
using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Services;

public class EjemplarService : IEjemplarService
{
    private readonly IEjemplarRepository _repo;

    public EjemplarService(IEjemplarRepository repo) => _repo = repo;

    public async Task<IReadOnlyList<EjemplarDto>> ListarAsync()
        => (await _repo.ListAsync()).Select(EjemplarMapper.ToDto).ToList();

    public async Task<EjemplarDto> CrearAsync(CrearEjemplarRequest request)
    {
        if (request.LibroId <= 0)
            throw new ArgumentException("LibroId inválido.");

        var entity = EjemplarMapper.ToEntity(request);
        await _repo.AddAsync(entity);
        return EjemplarMapper.ToDto(entity);
    }
}
