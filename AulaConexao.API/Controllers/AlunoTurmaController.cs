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
    public class AlunoTurmaController : ControllerBase
    {
        private readonly AlunoTurmaRepository repo;
        private readonly IMapper _mapper;


        public AlunoTurmaController(IMapper mapper)
        {
            repo = new AlunoTurmaRepository();
            _mapper = mapper;
        }

        // GET: api/<AlunoTurmaController>
        [HttpGet]
        public IActionResult Get()
        {
            var alunosTurmas = repo.GetAll();
            return Ok(_mapper.Map<IEnumerable<AlunoTurmaDto>>(alunosTurmas));           

        }

        // GET api/<AlunoTurmaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var alunosTurmas = repo.GetById(id);
            if (alunosTurmas == null)
                return BadRequest("AlunoTurma não encontrado.");

            return Ok(_mapper.Map<AlunoTurmaDto>(alunosTurmas));            
        }

        // POST api/<AlunoTurmaController>
        [HttpPost]
        public IActionResult Post(AlunoTurma alunosTurmas)
        {
            repo.Post(alunosTurmas);
            return Ok(alunosTurmas);
        }

        // PUT api/<AlunoTurmaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoTurma alunosTurmas)
        {
            var resposta = repo.Update(id, alunosTurmas);

            if (resposta)
                return Ok("AlunoTurma alterado com sucesso.");

            return BadRequest("AlunoTurma não encontrado.");
        }

        // DELETE api/<AlunoTurmaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alunosTurmas = repo.GetById(id);

            if (alunosTurmas == null) return BadRequest("O AlunoTurma não foi encontrado");

            repo.Delete(alunosTurmas);

            return Ok("AlunoTurma deletado com sucesso.");
        }
    }
}
