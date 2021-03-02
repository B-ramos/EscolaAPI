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

        // GET: api/<AlunoTurmaController>
        [HttpGet]
        public IActionResult Get()
        {
            var alunosTurmas = _repo.GetAll();
            return Ok(_mapper.Map<IEnumerable<AlunoTurmaDto>>(alunosTurmas));           

        }

        // GET api/<AlunoTurmaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var alunosTurmas = _repo.FindById(id);
            if (alunosTurmas == null)
                return BadRequest("AlunoTurma não encontrado.");

            return Ok(_mapper.Map<AlunoTurmaDto>(alunosTurmas));            
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
