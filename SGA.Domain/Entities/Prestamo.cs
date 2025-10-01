namespace SGA.Domain.Entities;

public class Prestamo
{
    public int Id { get; set; }
    public int EjemplarId { get; set; }
    public Ejemplar? Ejemplar { get; set; }

    public DateTime Fecha { get; set; }
    public DateTime Vence { get; set; }
    public DateTime? Devuelto { get; set; }
}
