
namespace SGA.Model.Requests
{

    public class ActualizarLibroRequest
    {
  
        public int Id { get; set; }

    
        public string Titulo { get; set; } = string.Empty;

        public int AutorId { get; set; }
    }
}
