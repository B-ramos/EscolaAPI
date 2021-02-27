using AulaConexao.API.Dto;
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
        private readonly TurmaProfessorRepository repo;
        private readonly IMapper _mapper;


        public TurmaProfessorController(IMapper mapper)
        {
            repo = new TurmaProfessorRepository();
            _mapper = mapper;
        }

        // GET: api/<TurmaProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            var turmaProfessores = repo.GetAll();
            return Ok(_mapper.Map<IEnumerable<TurmaProfessorDto>>(turmaProfessores));
            //return Ok(turmaProfessores);

        }

        // GET api/<TurmaProfessorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var turmaProfessor = repo.GetById(id);
            if (turmaProfessor == null)
                return BadRequest("TurmaProfessor não encontrado.");

            //return Ok(_mapper.Map<TurmaProfessorDto>(TurmaProfessor));
            return Ok(turmaProfessor);
        }

        // POST api/<TurmaProfessorController>
        [HttpPost]
        public IActionResult Post(TurmaProfessor turmaProfessor)
        {
            repo.Post(turmaProfessor);
            return Ok(turmaProfessor);
        }

        // PUT api/<TurmaProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, TurmaProfessor turmaProfessor)
        {
            var resposta = repo.Update(id, turmaProfessor);

            if (resposta)
                return Ok("TurmaProfessor alterado com sucesso.");

            return BadRequest("TurmaProfessor não encontrado.");
        }

        // DELETE api/<TurmaProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var turmaProfessor = repo.GetById(id);

            if (turmaProfessor == null) return BadRequest("O TurmaProfessor não foi encontrado");

            repo.Delete(turmaProfessor);

            return Ok("TurmaProfessor deletado com sucesso.");
        }
    }
}
