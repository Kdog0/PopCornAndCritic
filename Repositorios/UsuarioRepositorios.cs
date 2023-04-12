using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TarefasSistemas.Data;
using TarefasSistemas.Models;
using TarefasSistemas.Repositorios.Interfaces;

namespace TarefasSistemas.Repositorios
{
    public class UsuarioRepositorios : IUsuariosRepositorio
    {   
        private readonly TarefasDoSistemaDbContext _dbContext;

        public UsuarioRepositorios(TarefasDoSistemaDbContext tarefasDoSistemaDbContext) 
        { 
            _dbContext = tarefasDoSistemaDbContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<List<UsuarioModel>> BuscandoTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

       
        public async Task<UsuarioModel> Adcionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null) { throw new NotImplementedException($"Usuario por Id:{id} não encontrado"); }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id) ?? throw new NotImplementedException($"Usuario por Id:{id} não encontrado");
            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Bio = usuario.Bio;
            usuarioPorId.UrlImg = usuario.UrlImg;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return usuarioPorId;
        }
    }
}
