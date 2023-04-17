using Microsoft.AspNetCore.Mvc;
using TarefasSistemas.Data;
using TarefasSistemas.Data.Map;
using TarefasSistemas.Data.Map.DotLog;
using TarefasSistemas.Models;
using TarefasSistemas.Repositorios;
using TarefasSistemas.Repositorios.Interfaces;

namespace TarefasSistemas.Controllers
{
    [Route("comentario/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IComment _comment;
        private readonly IMoviesRepositorio _moviesRepositorio;

        public CommentController(IComment comment, IMoviesRepositorio moviesRepositorio)
        {
            _comment = comment;
            _moviesRepositorio = moviesRepositorio;
        }

        [HttpPost("comentarios")]
        public async Task<ActionResult<ComentarioModel>> Cadastrando([FromBody] ComentarioModel Comment, int muvId, int id)
        {
            
            ComentarioModel comentario = await _comment.Adcionar(Comment, id, muvId);
            List<Movie> movies = await _moviesRepositorio.BuscarTodosFilmes();
            var filme = movies.FirstOrDefault(x => x.Id == comentario.MovieId);


            comentario.Movie = filme;

            return Ok(comentario);

        }

        [HttpGet("todos")]
        public async Task<ActionResult<List<ComentarioModel>>> Buscando(int id)
        {
           
            List<ComentarioModel> comentarios = await _comment.TodosComentarioFilme(id);
            

            List<Movie> movies = await _moviesRepositorio.BuscarTodosFilmes();
            var filme = movies.FirstOrDefault(x => x.Id == id);

            CommentDtoFilmes commentDtoFilmes = new CommentDtoFilmes();

            commentDtoFilmes.Id = id;
            commentDtoFilmes.comment = comentarios;
            commentDtoFilmes.movie = filme;
             


            return Ok(commentDtoFilmes);
        }
    }   
}
