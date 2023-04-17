using Microsoft.EntityFrameworkCore;
using TarefasSistemas.Data;
using TarefasSistemas.Models;
using TarefasSistemas.Repositorios.Interfaces;

namespace TarefasSistemas.Repositorios
{
    public class MovieRepositorios : IMoviesRepositorio
    {
        private readonly TarefasDoSistemaDbContext _db;

        public MovieRepositorios(TarefasDoSistemaDbContext db)
        {
            _db = db;
        }

        public async Task<List<Movie>> BuscarTodosFilmes()
        {
            return await _db.Movies.ToListAsync();
        }

        public Task<Movie> BuscarFilme()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> BuscarGeneros()
        {
            throw new NotImplementedException();
        }


        public async Task<Movie> Cadastro(Movie movie)
        {
            await _db.Movies.AddAsync(movie);
            await _db.SaveChangesAsync();

            return movie;
           
        }
    }
}
