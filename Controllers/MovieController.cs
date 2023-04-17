using Microsoft.AspNetCore.Mvc;
using TarefasSistemas.Models;
using TarefasSistemas.Repositorios;
using TarefasSistemas.Repositorios.Interfaces;

namespace TarefasSistemas.Controllers
{
    [Route("filme/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMoviesRepositorio _moviesRepositorio;

        public MovieController(IMoviesRepositorio moviesRepositorio)
        {
            _moviesRepositorio = moviesRepositorio;
        }

        [HttpGet("todos")]
        public async Task<ActionResult<List<Movie>>> BuscandoTodosFilmes()
        {
            
            return await _moviesRepositorio.BuscarTodosFilmes();
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult<Movie>> Cadastrando([FromBody] Movie movieModel)
        {
            Movie movie = await _moviesRepositorio.Cadastro(movieModel);
            return Ok(movie);
        }

        [HttpGet("genre")]
        public async Task<ActionResult<List<Movie>>> BuscaGenero(string genre)
        {
          List<Movie> movies = await _moviesRepositorio.BuscarTodosFilmes();
          List<Movie> busca = movies.Where(x => x.Genre == genre).ToList();
         
          return Ok(busca);
        }

    }
}
