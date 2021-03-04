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
        private readonly IAlunoTurmaRepository _repo;
        private readonly IMapper _mapper;


        public AlunoTurmaController(IAlunoTurmaRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna uma lista com os aluno e o curso que ele está participando.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/AlunoTurma
        /// </remarks>
        /// <response code="200">Retorna a lista de alunos.</response>
        /// <response code="500">Exceção.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpGet]
        public IActionResult Get()
        {            
            try
            {
                var alunosTurmas = _repo.GetAll();
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
        /// <response code="500">Exceção.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var alunosTurmas = _repo.GetByIdAluno(id);
                if (alunosTurmas.Count < 1)
                    return BadRequest("Aluno não encontrado.");

                return Ok(_mapper.Map<IEnumerable<AlunoTurmaDto>>(alunosTurmas));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
                      
        }

        // POST api/<AlunoTurmaController>
        [HttpPost]
        public IActionResult Post(AlunoTurma alunosTurmas)
        {
            _repo.Create(alunosTurmas);
            return Ok(alunosTurmas);
        }

        // PUT api/<AlunoTurmaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(AlunoTurma alunosTurmas)
        {
            var resposta = _repo.Update(alunosTurmas);

            if (resposta == null)
                return BadRequest("AlunoTurma não encontrado.");

            return Ok("AlunoTurma alterado com sucesso.");
        }

        // DELETE api/<AlunoTurmaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alunosTurmas = _repo.FindById(id);

            if (alunosTurmas == null) return BadRequest("O AlunoTurma não foi encontrado");

            _repo.Remove(alunosTurmas.Id);

            return Ok("AlunoTurma deletado com sucesso.");
        }
    }
}
