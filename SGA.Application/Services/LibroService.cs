using SGA.Application.Interfaces;
using SGA.Domain.Entities;
using SGA.Domain.Repository;
using SGA.Model.Dtos;
using SGA.Model.Requests;

namespace SGA.Application.Services
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _repo;

        public LibroService(ILibroRepository repo)
        {
            _repo = repo;
        }

        public async Task<IReadOnlyList<LibroDto>> ListarAsync()
        {
            var libros = await _repo.ListAsync(); // IEnumerable<Libro> o IReadOnlyList<Libro>

            return libros
                .Select(l => new LibroDto
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    AutorId = l.AutorId
                })
                .ToList()
                .AsReadOnly();
        }

        public async Task<LibroDto?> BuscarPorIdAsync(int id)
        {
            var libro = await _repo.GetByIdAsync(id);
            if (libro == null) return null;

            return new LibroDto
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                AutorId = libro.AutorId
            };
        }

        public async Task<LibroDto> CrearAsync(CrearLibroRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Titulo))
            {
                throw new ArgumentException("El título no puede estar vacío.", nameof(request.Titulo));
            }

            var libro = new Libro
            {
                Titulo = request.Titulo,
                AutorId = request.AutorId
            };

            await _repo.AddAsync(libro);

            return new LibroDto
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                AutorId = libro.AutorId
            };
        }

        public async Task ActualizarAsync(int id, CrearLibroRequest request)
        {
            var libro = await _repo.GetByIdAsync(id);
            if (libro == null)
            {
                throw new ArgumentException("El libro no existe.", nameof(id));
            }

            libro.Titulo = request.Titulo;
            libro.AutorId = request.AutorId;

            await _repo.UpdateAsync(libro);
        }

        public async Task EliminarAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}
