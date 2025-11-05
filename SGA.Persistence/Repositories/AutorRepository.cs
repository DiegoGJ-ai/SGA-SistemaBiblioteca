using SGA.Domain.Entities;
using SGA.Domain.Repository;
using SGA.Persistence.Base;
using SGA.Persistence.Context;

namespace SGA.Persistence.Repositories
{
    public class AutorRepository : BaseRepository<Autor>, IAutorRepository
    {
        public AutorRepository(LibraryContext context) : base(context)
        {
        }

        
    }
}
