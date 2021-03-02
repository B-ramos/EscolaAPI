using AulaConexao.API.Dto;
using AulaConexao.Data.Interface;
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
        private readonly ITurmaProfessorRepository _repo;
        private readonly IMapper _mapper;


        public TurmaProfessorController(ITurmaProfessorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/<TurmaProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            var turmaProfessores = _repo.GetAll();
            return Ok(_mapper.Map<IEnumerable<TurmaProfessorDto>>(turmaProfessores));           

        }

        // GET api/<TurmaProfessorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var turmaProfessor = _repo.FindById(id);
            if (turmaProfessor == null)
                return BadRequest("TurmaProfessor não encontrado.");

            return Ok(_mapper.Map<TurmaProfessorDto>(turmaProfessor));            
        }

        // POST api/<TurmaProfessorController>
        [HttpPost]
        public IActionResult Post(TurmaProfessor turmaProfessor)
        {
            _repo.Create(turmaProfessor);
            return Ok(turmaProfessor);
        }

        // PUT api/<TurmaProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(TurmaProfessor turmaProfessor)
        {
            var resposta = _repo.Update(turmaProfessor);

            if (resposta == null)
                return BadRequest("TurmaProfessor não encontrado.");

            return Ok("TurmaProfessor alterado com sucesso.");
        }

        // DELETE api/<TurmaProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var turmaProfessor = _repo.FindById(id);

            if (turmaProfessor == null) return BadRequest("O TurmaProfessor não foi encontrado");

            _repo.Remove(turmaProfessor.Id);

            return Ok("TurmaProfessor deletado com sucesso.");
        }
    }
}
