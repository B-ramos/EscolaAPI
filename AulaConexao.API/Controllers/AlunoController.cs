using AulaConexao.API.Dto;
using AulaConexao.Data.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.AulaConexao.Domain;
using System.Collections.Generic;

namespace AulaConexao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository __repo;
        //private readonly ILogger __logger;
        private readonly IMapper _mapper;

        public AlunoController(IAlunoRepository repo, IMapper mapper, ILogger<AlunoController> logger)
        {
            __repo = repo;
            _mapper = mapper;
            //__logger = logger;
        }

        /// <summary>
        /// Retorna uma lista de Alunos.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/aluno
        /// </remarks>
        /// <response code="200">Retorna a lista de alunos.</response>
        /// <response code="204">Não encontrou nenhum aluno.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var alunos = __repo.FindAll();

                if (alunos.Count < 1)
                    return NoContent();

                return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
            }
            catch (System.Exception)
            {
                return StatusCode(500);                
            }
        }


        /// <summary>
        /// Retorna um  Aluno pelo seu Id.
        /// </summary>
        /// /// <param name="id">Identificador do Aluno.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/aluno/1
        /// </remarks>
        /// <response code="200">Retorna um aluno pelo seu Id.</response>
        /// <response code="204">Aluno não foi encontrado.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {            
            try
            {
                var aluno = __repo.FindById(id);
                if (aluno == null)
                    return NoContent();

                return Ok(_mapper.Map<AlunoDto>(aluno));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Cria um novo Aluno e retorna o mesmo.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Post /api/aluno
        ///     
        ///         {
        ///             "nome" : "nomeAluno",
        ///             "ativo" : true
        ///         }
        /// </remarks>
        /// <response code="201">Cria um novo aluno e retorna o mesmo.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {            
            try
            {
                __repo.Create(aluno);
                return Created($"https://localhost:44308/api/aluno/{aluno.Id}",aluno);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera um  Aluno.
        /// </summary>
        /// <param name="aluno">Identificador do Aluno.</param>
        /// <remarks>
        /// Exemplo de request:        
        ///     Put /api/aluno/1
        ///     
        ///         {
        ///             "id": 1,
        ///             "nome" : "nomeAluno",
        ///             "ativo" : true
        ///         }
        /// </remarks>
        /// <response code="201">Retorna o aluno alterado.</response>
        /// <response code="204">Aluno não foi encontrado.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpPut("{id}")]
        public IActionResult Put(Aluno aluno)
        {
            try
            {
                var resposta = __repo.Update(aluno);

                if (resposta == null)
                    return NoContent();

                return Created("Aluno alterado com sucesso.", aluno);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }            
        }

        /// <summary>
        /// Deleta um  Aluno pelo Id.
        /// </summary>
        /// /// <param name="id">Identificador do Aluno.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Delete /api/aluno/1        
        ///       
        /// </remarks>
        /// <response code="200">O aluno foi removido com sucesso.</response>
        /// <response code="204">Aluno não foi encontrado.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {            
            try
            {
                var aluno = __repo.FindById(id);

                if (aluno == null) return NoContent();

                __repo.Remove(aluno.Id);

                return Ok("Aluno deletado com sucesso.");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
