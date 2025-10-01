namespace SGA.Domain.Entities;

public class Reserva
{
    public int Id { get; set; }
    public int LibroId { get; set; }
    public Libro? Libro { get; set; }
    public DateTime Fecha { get; set; }
    public bool Notificado { get; set; }
}
