
using TarefasSistemas.Models;

namespace TarefasSistemas.Repositorios.Interfaces
{
    public interface IUsuariosRepositorio
    {
        Task<List<UsuarioModel>> BuscandoTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adcionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
        Task<bool> Apagar(int id);
    }
}
