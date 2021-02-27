using AulaConexao.API.Dto;
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
        private readonly TurmaRepository repo;
        private readonly IMapper _mapper;


        public TurmaController(IMapper mapper)
        {
            repo = new TurmaRepository();
            _mapper = mapper;
        }

        // GET: api/<TurmaController>
        [HttpGet]
        public IActionResult Get()
        {
            var turmas = repo.GetAll();
            //return Ok(turmas);
            return Ok(_mapper.Map<IEnumerable<TurmaDto>>(turmas));

        }

        // GET api/<TurmaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var turma = repo.GetById(id);
            if (turma == null)
                return BadRequest("Turma não encontrado.");

            return Ok(_mapper.Map<TurmaDto>(turma));
        }

        // POST api/<TurmaController>
        [HttpPost]
        public IActionResult Post(Turma turma)
        {
            repo.Post(turma);
            return Ok(turma);
        }

        // PUT api/<TurmaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Turma turma)
        {
            var resposta = repo.Update(id, turma);

            if (resposta)
                return Ok("Turma alterada com sucesso.");

            return BadRequest("Turma não encontrada.");
        }

        // DELETE api/<TurmaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var turma = repo.GetById(id);

            if (turma == null) return BadRequest("O Turma não foi encontrada");

            repo.Delete(turma);

            return Ok("Turma deletada com sucesso.");
        }
    }
}
