using AulaConexao.API.Dto;
using AulaConexao.Data.Interface;
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
        private readonly IProfessorRepository _repo;
        private readonly IMapper _mapper;


        public ProfessorController(IProfessorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.FindAll();
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
            //return Ok(professores);

        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var professor = _repo.FindById(id);
            if (professor == null)
                return BadRequest("Professor não encontrado.");

            return Ok(_mapper.Map<ProfessorDto>(professor));

        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult Post(Professor Professor)
        {
            _repo.Create(Professor);
            return Ok(Professor);
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Professor professor)
        {
            var resposta = _repo.Update(professor);

            if (resposta == null)
                return BadRequest("Professor não encontrado.");

            return Ok("Professor alterado com sucesso.");
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.FindById(id);

            if (professor == null) return BadRequest("O Professor não foi encontrado");

            _repo.Remove(professor.Id);

            return Ok("Professor deletado com sucesso.");
        }
    }
}
