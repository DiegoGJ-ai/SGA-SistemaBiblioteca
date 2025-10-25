using SGA.Domain.Entities;
using SGA.Domain.Repository;
using SGA.Persistence.Base;
using SGA.Persistence.Context;

namespace SGA.Persistence.Repositories;

public class ReservaRepository : BaseRepository<Reserva>, IReservaRepository
{
    public ReservaRepository(LibraryContext context) : base(context) { }
}
