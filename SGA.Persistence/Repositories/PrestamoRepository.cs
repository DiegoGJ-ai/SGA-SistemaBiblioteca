using SGA.Domain.Entities;
using SGA.Domain.Repository;
using SGA.Persistence.Base;
using SGA.Persistence.Context;

namespace SGA.Persistence.Repositories;

public class PrestamoRepository : BaseRepository<Prestamo>, IPrestamoRepository
{
    public PrestamoRepository(LibraryContext context) : base(context) { }
}
