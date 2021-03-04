using AulaConexao.API.Dto;
using AulaConexao.Data.Interface;
using AulaConexao.Data.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.AulaConexao.Domain;
using System.Collections;
using System.Collections.Generic;

namespace AulaConexao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository _repo;
        private readonly IMapper _mapper;


        public ProfessorController(IProfessorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna uma lista de Professores.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/professor
        /// </remarks>
        /// <response code="200">Retorna a lista de professores.</response>
        /// <response code="204">Não encontrou nenhum professor.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var professores = _repo.FindAll();

                if (professores.Count < 1)
                    return NoContent();

                return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }


        /// <summary>
        /// Retorna um  Professor pelo seu Id.
        /// </summary>
        /// /// <param name="id">Identificador do Professor.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/professor/1
        /// </remarks>
        /// <response code="200">Retorna um professor pelo seu Id.</response>
        /// <response code="204">Professor não foi encontrado.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var professor = _repo.FindById(id);
                if (professor == null)
                    return NoContent();

                return Ok(_mapper.Map<ProfessorDto>(professor));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Cria um novo Professor e retorna o mesmo.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:        
        ///     Post /api/professor
        /// 
        ///         {
        ///             "nome" : "nomeProfessor",
        ///             "email" : "professor@email.com",
        ///             "turno" : 1
        ///         }
        ///         
        ///     Referência para Turnos - 1: Manha, 2: Tarde, 3: Noite, 4: Integral        
        /// </remarks>        
        /// <response code="201">Cria um novo professor e retorna o mesmo.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            try
            {
                _repo.Create(professor);
                return Created($"https://localhost:44308/api/professor/{professor.Id}", professor);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera um  Professor.
        /// </summary>
        /// <param name="professor">Identificador do Professor.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Put /api/professor/1
        ///     {
        ///         "id": 1,
        ///         "nome" : "nomeProfessor",
        ///         "ativo" : true
        ///     }
        /// </remarks>
        /// <response code="201">Retorna o professor alterado.</response>
        /// <response code="204">Professor não foi encontrado.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpPut("{id}")]
        public IActionResult Put(Professor professor)
        {
            try
            {
                var resposta = _repo.Update(professor);

                if (resposta == null)
                    return NoContent();

                return Created("Professor alterado com sucesso.", professor);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Deleta um  Professor pelo Id.
        /// </summary>
        /// /// <param name="id">Identificador do Professor.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Delete /api/professor/1        
        ///       
        /// </remarks>
        /// <response code="200">O professor foi removido com sucesso.</response>
        /// <response code="204">Professor não foi encontrado.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var professor = _repo.FindById(id);

                if (professor == null) return NoContent();

                _repo.Remove(professor.Id);

                return Ok("Professor deletado com sucesso.");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
