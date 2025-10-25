namespace SGA.Model.Dtos;

public sealed class PrestamoDto
{
    public int Id { get; set; }
    public int EjemplarId { get; set; }
    public DateTime Fecha { get; set; }
    public DateTime Vence { get; set; }
}
