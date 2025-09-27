using System.ComponentModel.DataAnnotations;

namespace SGA.Model.Requests;

public class UpdateLibroRequest : CreateLibroRequest
{
    [Required]
    public int Id { get; set; }
}
