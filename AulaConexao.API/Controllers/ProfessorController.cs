using AulaConexao.API.Dto;
using AulaConexao.Data.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.AulaConexao.Domain;
using System.Collections;
using System.Collections.Generic;

namespace AulaConexao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorRepository repo;
        private readonly IMapper _mapper;


        public ProfessorController(IMapper mapper)
        {
            repo = new ProfessorRepository();
            _mapper = mapper;
        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            var professores = repo.GetAll();
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
            //return Ok(professores);

        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var professor = repo.GetById(id);
            if (professor == null)
                return BadRequest("Professor não encontrado.");

            return Ok(_mapper.Map<ProfessorDto>(professor));

        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult Post(Professor Professor)
        {
            repo.Post(Professor);
            return Ok(Professor);
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var resposta = repo.Update(id, professor);

            if (resposta)
                return Ok("Professor alterado com sucesso.");

            return BadRequest("Professor não encontrado.");
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = repo.GetById(id);

            if (professor == null) return BadRequest("O Professor não foi encontrado");

            repo.Delete(professor);

            return Ok("Professor deletado com sucesso.");
        }
    }
}
