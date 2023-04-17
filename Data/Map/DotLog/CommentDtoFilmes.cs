using TarefasSistemas.Models;

namespace TarefasSistemas.Data.Map.DotLog
{
    public class CommentDtoFilmes
    {   
        public int Id { get; set; }
        public List<ComentarioModel> comment { get; set; }
        public Movie movie  { get; set; }
        public static implicit operator CommentDtoFilmes(ComentarioModel v)
        {
            throw new NotImplementedException();
        }
    }
}
