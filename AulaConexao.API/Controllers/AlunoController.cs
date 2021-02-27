using AulaConexao.API.Dto;
using AulaConexao.Data.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.AulaConexao.Domain;
using System.Collections.Generic;

namespace AulaConexao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoRepository repo;
        private readonly IMapper _mapper;

        public AlunoController(IMapper mapper)
        {
            repo = new AlunoRepository();
            _mapper = mapper;
        }
        

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = repo.GetAll();
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var aluno = repo.GetById(id);
            if (aluno == null)
                return BadRequest("Aluno não encontrado.");

            return Ok(_mapper.Map<AlunoDto>(aluno));

        }

        // POST api/<AlunoController>
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            repo.Post(aluno);
            return Ok(aluno);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var resposta = repo.Update(id, aluno);

            if(resposta)
                return Ok("Aluno alterado com sucesso.");

            return BadRequest("Aluno não encontrado.");
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = repo.GetById(id);

            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            repo.Delete(aluno);

            return Ok("Aluno deletado com sucesso.");
        }
    }
}
