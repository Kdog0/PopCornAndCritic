using TarefasSistemas.Models;
using TarefasSistemas.Repositorios.Interfaces;

namespace TarefasSistemas.Repositorios
{
    public class MovieRepositorios : IMoviesRepositorio
    {
        public Task<Movie> BuscarFilme()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> BuscarGenero()
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> BuscarTodosFilmes()
        {
            throw new NotImplementedException();
        }
    }
}
