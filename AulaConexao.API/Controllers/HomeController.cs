using AulaConexao.API.Services;
using AulaConexao.Data.Interface;
using AulaConexao.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AulaConexao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUsuarioRepository _repo;

        public HomeController(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] Usuario usuarioDto)
        {
            try
            {
                if (string.IsNullOrEmpty(usuarioDto.Nome) || string.IsNullOrEmpty(usuarioDto.Senha))
                    return BadRequest("Nome e/ou senha não devem ser nulas");

                var usuario = _repo.SelecionarPorNomeESenha(usuarioDto.Nome, usuarioDto.Senha);
                if (usuario == null)
                    return NotFound("Nome e/ou senha inválido(s)");

                var token = TokenService.GerarToken(usuario);

                return Ok(token);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
        
            }           
        }
    }
}
