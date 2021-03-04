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
    public class AlunoTurmaController : ControllerBase
    {
        private readonly IAlunoRepository _repoAluno;
        private readonly IAlunoTurmaRepository _repo;
        private readonly ITurmaRepository _repoTurma;
        private readonly IMapper _mapper;


        public AlunoTurmaController(IAlunoTurmaRepository repo, 
                                    IAlunoRepository repoAluno, 
                                    ITurmaRepository repoTurma,
                                    IMapper mapper)
        {
            _repo = repo;
            _repoAluno = repoAluno;
            _repoTurma = repoTurma;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna uma lista com os aluno e o curso que ele está participando.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/AlunoTurma
        /// </remarks>
        /// <response code="200">Retorna uma lista com aluno e o curso que ele está participando.</response>
        /// <response code="204">Lista vazia.</response>
        /// <response code="500">Exceção.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [HttpGet]
        public IActionResult Get()
        {            
            try
            {
                var alunosTurmas = _repo.FindAll();

                if (alunosTurmas.Count < 1)
                    return NoContent();

                return Ok(_mapper.Map<IEnumerable<AlunoTurmaDto>>(alunosTurmas));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna lista de AlunoTurmas por Id do Aluno.
        /// </summary>
        /// <param name="id">Identificador do aluno.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/AlunoTurma/1
        /// </remarks>
        /// <response code="200">Retorna as turmas referente ao Id do aluno.</response>
        /// <response code="204">Aluno não existe.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var alunosTurmas = _repo.FindByIdAluno(id);

                if (alunosTurmas.Count < 1)
                    return NoContent();

                return Ok(_mapper.Map<IEnumerable<AlunoTurmaDto>>(alunosTurmas));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
                      
        }

        /// <summary>
        /// Inclui o aluno no curso.
        /// </summary>
        /// /// /// <param name="alunosTurmas">Identificador do Professor.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Post /api/aluno
        ///     
        ///         {
        ///             "alunoID" : 1,
        ///             "turmaId" :1
        ///         }
        /// </remarks>
        /// <response code="201">Inclui o aluno na turma.</response>
        /// <response code="204">Aluno ou turma não existe.</response>
        /// <response code="400">Aluno ja cadastrado no curso.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post(AlunoTurma alunosTurmas)
        {
            try
            {
                var aluno = _repoAluno.FindById(alunosTurmas.AlunoId);
                var turma = _repoTurma.FindById(alunosTurmas.TurmaId);
                if (aluno == null || turma == null) return NoContent();

                var resposta =_repo.CreateAlunoTurma(alunosTurmas);

                if (resposta) 
                    return Created($"https://localhost:44308/api/alunoturma/{alunosTurmas.AlunoId}", alunosTurmas);

                return BadRequest("Aluno ja está cadastrado nesta turma");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }


        //[HttpPut("{id}")]
        //public IActionResult Put(AlunoTurma alunosTurmas)
        //{
        //    var resposta = _repo.Update(alunosTurmas);

        //    if (resposta == null)
        //        return BadRequest("AlunoTurma não encontrado.");

        //    return Ok("AlunoTurma alterado com sucesso.");

        //}


        /// <summary>
        /// Excluir o Aluno do curso pelo Id do aluno.
        /// </summary>
        /// <param name="alunoId"></param>
        /// <param name="turmaId"></param>
        /// <remarks>
        /// Exemplo de request:
        ///     Delete /api/alunoturma/1        
        ///       
        /// </remarks>
        /// <response code="200">O aluno foi removido com sucesso.</response>
        /// <response code="204">Aluno não foi encontrado.</response>
        /// <response code="400">Aluno existe, porém não está cadastrado neste curso.</response>
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpDelete("{alunoId}/{turmaId}")]
        public IActionResult Delete(int alunoId, int turmaId)
        {
            try
            {
                var aluno = _repoAluno.FindById(alunoId);
                var turma = _repoTurma.FindById(turmaId);
                if (aluno == null || turma == null) return NoContent();                

                var resposta = _repo.RemoveAlunoTurma(alunoId, turmaId);

                if(resposta)
                    return Ok("Aluno foi removido da turma.");

                return BadRequest("O aluno existe, porém não está cadastrado neste curso.");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }


            
        }
    }
}
