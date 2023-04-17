using Microsoft.EntityFrameworkCore;
using TarefasSistemas.Data;
using TarefasSistemas.Models;
using TarefasSistemas.Repositorios.Interfaces;

namespace TarefasSistemas.Repositorios
{
    public class ComentarioRepositorio : IComment
    {
        private readonly TarefasDoSistemaDbContext _db;

        public ComentarioRepositorio(TarefasDoSistemaDbContext tarefasDoSistemaDbContext)
        {
            _db = tarefasDoSistemaDbContext;
        }

        public async Task<ComentarioModel> Adcionar(ComentarioModel comentario, int id, int muvId)
        {
            
            comentario.Movie = await _db.Movies.FirstOrDefaultAsync(x => x.Id == muvId);   
            comentario.User = await _db.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            
           await _db.Comentarios.AddAsync(comentario);
           await _db.SaveChangesAsync();
           return comentario;
        }

        public async Task<List<ComentarioModel>> TodosComentarioFilme( int id)
        {
            var filmes = _db.Movies.FirstOrDefault(x => x.Id == id);
            
            if (filmes == null)
            {
                // Se o filme não for encontrado, retorne uma lista vazia ou uma exceção, dependendo do comportamento desejado.
                 throw new NotImplementedException();
            }

            var comentarios = _db.Comentarios.Where(x => x.MovieId == filmes.Id).ToList();

            

          
            return comentarios;
        }


        public Task<List<ComentarioModel>> TodosComentarioUser()
        {
            throw new NotImplementedException();
        }

      
    }
}
