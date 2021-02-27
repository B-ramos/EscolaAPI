using AulaConexao.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Models.AulaConexao.Domain;

namespace AulaConexao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoRepository repo;

        public AlunoController()
        {
            repo = new AlunoRepository();
        }
        

        // GET: api/<AlunoController>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = repo.GetAll();
            return Ok(alunos);
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var aluno = repo.GetById(id);
            if (aluno == null)
                return BadRequest("Aluno não encontrado.");

            return Ok(aluno);

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
