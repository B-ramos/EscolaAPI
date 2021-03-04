using AulaConexao.API.Dto;
using AulaConexao.Data.Interface;
using AulaConexao.Data.Repository;
using AulaConexao.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AulaConexao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _repo;
        private readonly IMapper _mapper;


        public TurmaController(ITurmaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        /// <summary>
        /// Retorna uma lista de Turmas.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/turma/
        /// </remarks>
        /// <response code="200">Retorna a lista de turmas.</response>
        /// <response code="204">Não encontrou nenhuma turma.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var turmas = _repo.FindAll();

                if (turmas.Count < 1)
                    return NoContent();

                return Ok(_mapper.Map<IEnumerable<TurmaDto>>(turmas));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }


        /// <summary>
        /// Retorna uma  Turma pelo seu Id.
        /// </summary>
        /// /// <param name="id">Identificador da Turma.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/turma/1
        /// </remarks>
        /// <response code="200">Retorna uma turma pelo seu Id.</response>
        /// <response code="204">Turma não foi encontrado.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var turma = _repo.FindById(id);
                if (turma == null)
                    return NoContent();

                return Ok(_mapper.Map<TurmaDto>(turma));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Cria um novo Turma e retorna o mesmo.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Post /api/turma
        ///     
        ///         {
        ///             "nome" : "nomeTurma",
        ///             "descricao" : "Turma de c#"
        ///         }
        /// </remarks>
        /// <response code="201">Cria um nova turma e retorna a mesma.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post(Turma turma)
        {
            try
            {
                _repo.Create(turma);
                return Created("", turma);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera uma  Turma.
        /// </summary>
        /// <param name="turma">Identificador da Turma.</param>
        /// <remarks>
        /// Exemplo de request:        
        ///     Put /api/turma/1
        ///     
        ///         {
        ///             "id": 1,
        ///             "nome" : "nomeTurma",
        ///             "descricao" : "alteraDescricao"
        ///         }
        /// </remarks>
        /// <response code="201">Retorna a turma alterado</response>
        /// <response code="204">Turma não foi encontrado.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpPut("{id}")]
        public IActionResult Put(Turma turma)
        {
            try
            {
                var resposta = _repo.Update(turma);

                if (resposta == null)
                    return NoContent();

                return Created("Turma alterado com sucesso.", turma);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta uma Turma pelo Id.
        /// </summary>
        /// /// <param name="id">Identificador da Turma.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Delete /api/turma/1        
        ///       
        /// </remarks>
        /// <response code="200">A turma foi removido com sucesso.</response>
        /// <response code="204">Turma não foi encontrado.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var turma = _repo.FindById(id);

                if (turma == null) return NoContent();

                _repo.Remove(turma.Id);

                return Ok("Turma deletado com sucesso.");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
