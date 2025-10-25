namespace SGA.Model.Requests;

public sealed class CrearPrestamoRequest
{
    public int EjemplarId { get; set; }
    public int Dias { get; set; } = 7;
}
