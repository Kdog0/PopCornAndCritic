using Microsoft.Identity.Client;

namespace TarefasSistemas.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string?  Email { get; set; }
        public string? UrlImg { get; set; }
        public string? Bio { get; set; }

        
    }
}
