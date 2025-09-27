using System.ComponentModel.DataAnnotations;

namespace SGA.Model.Requests;

public class CreateLibroRequest
{
    [Required, StringLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string Autor { get; set; } = string.Empty;

    [Range(1400, 3000)]
    public int? AnioPublicacion { get; set; }

    [StringLength(20)]
    public string? Isbn { get; set; }
}
