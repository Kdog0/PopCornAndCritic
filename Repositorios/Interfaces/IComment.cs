using TarefasSistemas.Models;

namespace TarefasSistemas.Repositorios.Interfaces
{
    public interface IComment 
    {
        Task<List<ComentarioModel>> TodosComentarioFilme(int id);
        Task<List<ComentarioModel>> TodosComentarioUser();
        Task<ComentarioModel> Adcionar(ComentarioModel comentario, int id, int muvId);
    }
}
