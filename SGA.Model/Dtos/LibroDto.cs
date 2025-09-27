namespace SGA.Model.Dtos;

public class LibroDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public int? AnioPublicacion { get; set; }
    public string? Isbn { get; set; }
}
