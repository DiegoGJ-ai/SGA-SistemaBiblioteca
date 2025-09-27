using SGA.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGA.Application.Interfaces
{
    public interface ILibroService
    {
        Task<IReadOnlyList<Libro>> ListarAsync();
    }
}