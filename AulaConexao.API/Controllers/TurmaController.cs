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

        // GET: api/<TurmaController>
        [HttpGet]
        public IActionResult Get()
        {
            var turmas = _repo.FindAll();
            //return Ok(turmas);
            return Ok(_mapper.Map<IEnumerable<TurmaDto>>(turmas));

        }

        // GET api/<TurmaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var turma = _repo.FindById(id);
            if (turma == null)
                return BadRequest("Turma não encontrado.");

            return Ok(_mapper.Map<TurmaDto>(turma));
        }

        // POST api/<TurmaController>
        [HttpPost]
        public IActionResult Post(Turma turma)
        {
            _repo.Create(turma);
            return Ok(turma);
        }

        // PUT api/<TurmaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Turma turma)
        {
            var resposta = _repo.Update(turma);

            if (resposta == null)
                return BadRequest("Turma não encontrada.");

            return Ok("Turma alterada com sucesso.");
        }

        // DELETE api/<TurmaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var turma = _repo.FindById(id);

            if (turma == null) return BadRequest("O Turma não foi encontrada");

            _repo.Remove(turma.Id);

            return Ok("Turma deletada com sucesso.");
        }
    }
}
