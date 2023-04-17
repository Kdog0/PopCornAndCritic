using TarefasSistemas.Models;

namespace TarefasSistemas.Repositorios.Interfaces
{
    public interface IMoviesRepositorio
    {
        Task<List<Movie>> BuscarTodosFilmes();
        Task<Movie> BuscarFilme();
        Task<Movie> BuscarGeneros();
        Task<Movie> Cadastro( Movie movie);
    }
}
