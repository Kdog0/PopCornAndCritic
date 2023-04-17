using System.ComponentModel.DataAnnotations.Schema;
using TarefasSistemas.Data.Map.DotLog;

namespace TarefasSistemas.Models
{
    public class ComentarioModel
    {  
        public int Id { get; set; }
        public string Comment { get; set; }
        public int MovieId {get;set;}
        public Movie Movie { get; set; }    
        public int UsuarioId { get; set;}
        public UsuarioModel User { get; set; }
    }
}
