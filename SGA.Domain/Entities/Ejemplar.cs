namespace SGA.Domain.Entities;

public class Ejemplar
{
    public int Id { get; set; }
    public int LibroId { get; set; }
    public Libro? Libro { get; set; }
    public bool Disponible { get; set; } = true;
}
