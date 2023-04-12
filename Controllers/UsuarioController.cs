using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.XPath;
using TarefasSistemas.Data.Map.DotLog;
using TarefasSistemas.Models;
using TarefasSistemas.Repositorios.Interfaces;

namespace TarefasSistemas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuariosRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscaTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscandoTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscaPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Adcionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atulizando([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Deletando(int id)
        {
            bool apagado = await _usuarioRepositorio.Apagar(id);
            return Ok(apagado);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<string>>> BuscandoNome()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscandoTodosUsuarios();
            List<string> emails = usuarios.Select(u => u.Email).ToList();
            return Ok(emails);
        }
        [HttpPost("LogIn")]
        public async Task<ActionResult<IEnumerable<DtoLogin>>> Logado([FromBody] DtoLogin dtoLogin)
        {
           
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscandoTodosUsuarios();

            UsuarioLidoDto user = new UsuarioLidoDto(); 
            UsuarioModel usuario = usuarios.FirstOrDefault(u => u.Email == dtoLogin.Email);

            user.Email = usuario.Email;
            user.Name = usuario.Name;
            user.Bio = usuario.Bio;
            user.UrlImg = usuario.UrlImg;
            user.Id = usuario.Id;

            if (usuario == null)
            {
                return BadRequest("E-mail ou senha inválidos.");
            }

            if (usuario.Password != dtoLogin.Password)
            {
                return BadRequest("E-mail ou senha inválidos.");
            }

            return Ok(user);

        }
    }
}
