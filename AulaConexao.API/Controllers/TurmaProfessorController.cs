using AulaConexao.API.Dto;
using AulaConexao.Data.Interface;
using AulaConexao.Data.Repository;
using AulaConexao.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.AulaConexao.Domain;
using System.Collections;
using System.Collections.Generic;

namespace AulaConexao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaProfessorController : ControllerBase
    {
        private readonly ITurmaProfessorRepository _repo;
        private readonly IMapper _mapper;


        public TurmaProfessorController(ITurmaProfessorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna uma lista de TurmasProfessores.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/TurmaProfessor
        /// </remarks>
        /// <response code="200">Retorna a lista com as turmas e professores.</response>
        /// <response code="500">Exceção.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [HttpGet]
        public IActionResult Get()
        {            
            try
            {
                var turmaProfessores = _repo.GetAll();
                return Ok(_mapper.Map<IEnumerable<TurmaProfessorDto>>(turmaProfessores));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }

        }

        /// <summary>
        /// Retorna lista de TurmaProfessor por Id do professor.
        /// </summary>
        /// <param name="id">Identificador do professor.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/turmaprofessor/1
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
                var turmaProfessor = _repo.GetByIdProfessor(id);
                if (turmaProfessor.Count < 1)
                    return BadRequest("professor não encontrado.");

                return Ok(_mapper.Map<IEnumerable<TurmaProfessorDto>>(turmaProfessor));
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        // POST api/<TurmaProfessorController>
        [HttpPost]
        public IActionResult Post(TurmaProfessor turmaProfessor)
        {
            _repo.Create(turmaProfessor);
            return Ok(turmaProfessor);
        }

        // PUT api/<TurmaProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(TurmaProfessor turmaProfessor)
        {
            var resposta = _repo.Update(turmaProfessor);

            if (resposta == null)
                return BadRequest("TurmaProfessor não encontrado.");

            return Ok("TurmaProfessor alterado com sucesso.");
        }

        // DELETE api/<TurmaProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var turmaProfessor = _repo.FindById(id);

            if (turmaProfessor == null) return BadRequest("O TurmaProfessor não foi encontrado");

            _repo.Remove(turmaProfessor.Id);

            return Ok("TurmaProfessor deletado com sucesso.");
        }
    }
}
