namespace SGA.Model.Requests;

public class CrearLibroRequest
{
    public string Titulo { get; set; } = string.Empty;
    public int AutorId { get; set; }
}
