using AulaConexao.API.Dto;
using AulaConexao.Data.Interface;
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
        private readonly IAlunoRepository __repo;
        private readonly IMapper _mapper;

        public AlunoController(IAlunoRepository repo, IMapper mapper)
        {
            __repo = repo;
            _mapper = mapper;
        }
        

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = __repo.FindAll();
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var aluno = __repo.FindById(id);
            if (aluno == null)
                return BadRequest("Aluno não encontrado.");

            return Ok(_mapper.Map<AlunoDto>(aluno));

        }

        // POST api/<AlunoController>
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            __repo.Create(aluno);
            return Ok(aluno);
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Aluno aluno)
        {
            var resposta = __repo.Update(aluno);

            if(resposta == null)
                return BadRequest("Aluno não encontrado.");
            
            return Ok("Aluno alterado com sucesso.");
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = __repo.FindById(id);

            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            __repo.Remove(aluno.Id);

            return Ok("Aluno deletado com sucesso.");
        }
    }
}
