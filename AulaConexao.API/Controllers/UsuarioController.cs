using AulaConexao.Data.Interface;
using AulaConexao.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AulaConexao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repo;
        
        public UsuarioController(IUsuarioRepository repo)
        {

            _repo = repo ?? throw new ArgumentNullException("UsuarioRepository não pode ser null");            
        }

        /// <summary>
        /// Cria um novo Usuario e retorna o mesmo.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Post /api/usuario
        ///     
        ///         {
        ///             "nome" : "nomeUsuario",
        ///             "senha" : "123456"
        ///         }
        /// </remarks>
        /// <response code="201">Cria um novo usuario e retorna o mesmo.</response>
        /// <response code="400">Nome ou Senha estão nulos.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.Nome) || string.IsNullOrEmpty(usuario.Senha))
                    return BadRequest("Nome é Senha são obrigatórios");

                _repo.Create(usuario);
                return Created($"https://localhost:44308/api/usuario/{usuario.Id}", usuario);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }            
        }

        ///// <summary>
        ///// Retorna uma lista de Usuarios.
        ///// </summary>
        ///// <remarks>
        ///// Exemplo de request:
        /////     Get /api/usuario
        ///// </remarks>
        ///// <response code="200">Retorna a lista de usuarios.</response>
        ///// <response code="204">Não encontrou nenhum usuario.</response>
        ///// <response code="500">Exceção.</response>
        //[ProducesResponseType(200)]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(500)]
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        var usuarios = _repo.FindAll();

        //        if (usuarios.Count < 1)
        //            return NoContent();

        //        return Ok(usuarios);
        //    }
        //    catch (System.Exception)
        //    {
        //        return StatusCode(500);                
        //    }
        //}


        ///// <summary>
        ///// Retorna um  Usuario pelo seu Id.
        ///// </summary>
        ///// /// <param name="id">Identificador do Usuario.</param>
        ///// <remarks>
        ///// Exemplo de request:
        /////     Get /api/usuario/1
        ///// </remarks>
        ///// <response code="200">Retorna um usuario pelo seu Id.</response>
        ///// <response code="204">Usuario não foi encontrado.</response>
        ///// <response code="500">Exceção.</response>
        //[ProducesResponseType(200)]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(500)]
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{            
        //    try
        //    {
        //        var usuario = _repo.FindById(id);
        //        if (usuario == null)
        //            return NoContent();

        //        return Ok(usuario);
        //    }
        //    catch (System.Exception)
        //    {
        //        return StatusCode(500);
        //    }
        //}

        ///// <summary>
        ///// Cria um novo Usuario e retorna o mesmo.
        ///// </summary>
        ///// <remarks>
        ///// Exemplo de request:
        /////     Post /api/usuario
        /////     
        /////         {
        /////             "nome" : "nomeUsuario",
        /////             "ativo" : true
        /////         }
        ///// </remarks>
        ///// <response code="201">Cria um novo usuario e retorna o mesmo.</response>
        ///// <response code="500">Exceção.</response>
        //[ProducesResponseType(201)]
        //[ProducesResponseType(500)]
        //[HttpPost]
        //public IActionResult Post(Usuario usuario)
        //{            
        //    try
        //    {
        //        _repo.Create(usuario);
        //        return Created($"https://localhost:44308/api/usuario/{usuario.Id}",usuario);
        //    }
        //    catch (System.Exception)
        //    {
        //        return StatusCode(500);
        //    }
        //}

        ///// <summary>
        ///// Altera um  Usuario.
        ///// </summary>
        ///// <param name="usuario">Identificador do Usuario.</param>
        ///// <remarks>
        ///// Exemplo de request:        
        /////     Put /api/usuario/1
        /////     
        /////         {
        /////             "id": 1,
        /////             "nome" : "nomeUsuario",
        /////             "ativo" : true
        /////         }
        ///// </remarks>
        ///// <response code="201">Retorna o usuario alterado.</response>
        ///// <response code="204">Usuario não foi encontrado.</response>
        ///// <response code="500">Exceção.</response>
        //[ProducesResponseType(200)]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(500)]
        //[HttpPut("{id}")]
        //public IActionResult Put(Usuario usuario)
        //{
        //    try
        //    {
        //        var resposta = _repo.Update(usuario);

        //        if (resposta == null)
        //            return NoContent();

        //        return Created("Usuario alterado com sucesso.", usuario);
        //    }
        //    catch (System.Exception)
        //    {
        //        return StatusCode(500);
        //    }            
        //}

        ///// <summary>
        ///// Deleta um  Usuario pelo Id.
        ///// </summary>
        ///// /// <param name="id">Identificador do Usuario.</param>
        ///// <remarks>
        ///// Exemplo de request:
        /////     Delete /api/usuario/1        
        /////       
        ///// </remarks>
        ///// <response code="200">O usuario foi removido com sucesso.</response>
        ///// <response code="204">Usuario não foi encontrado.</response>
        ///// <response code="500">Exceção.</response>
        //[ProducesResponseType(200)]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(500)]
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{            
        //    try
        //    {
        //        var usuario = _repo.FindById(id);

        //        if (usuario == null) return NoContent();

        //        _repo.Remove(usuario.Id);

        //        return Ok("Usuario deletado com sucesso.");
        //    }
        //    catch (System.Exception)
        //    {
        //        return StatusCode(500);
        //    }
        //}
    }
}
