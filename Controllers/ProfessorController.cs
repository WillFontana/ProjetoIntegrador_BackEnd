using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Data;
using ProjetoIntegrador.Data.Dtos.ProfessorDtos;
using ProjetoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        private MainContext _context;
        private IMapper _mapper;
        public ProfessorController(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IEnumerable<Professor> GetProfessores()
        {
            return _context.Professores;
        }
        [HttpGet("{cpf}")]
        public IActionResult GetProfessorByCpf(string cpf)
        {
            Professor professorGet = _context.Professores.FirstOrDefault(professorGet => professorGet.Cpf.Equals(cpf));

            if(professorGet != null)
            {
                ReadProfessorDto professorDto = _mapper.Map<ReadProfessorDto>(professorGet);

                return Ok(professorDto);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult AddProfessor([FromBody] CreateProfessorDto professorDto)
        {
            Professor newProfessor = _mapper.Map<Professor>(professorDto);

            _context.Professores.Add(newProfessor);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProfessorByCpf), new { newProfessor.Cpf }, newProfessor);
        }
        [HttpPut("{cpf}")]
        public IActionResult UpdateProfessor(string cpf, [FromBody] UpdateProfessorDto professorDto)
        {
            Professor professorUpdate = _context.Professores.FirstOrDefault(professorUpdate => professorUpdate.Cpf.Equals(cpf));

            if (professorUpdate == null)
            {
                return NotFound();
            }
            _mapper.Map(professorDto, professorUpdate);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{cpf}")]
        public IActionResult DeleteProfessor(string cpf)
        {
            Professor professorDelete = _context.Professores.FirstOrDefault(professorDelete => professorDelete.Cpf.Equals(cpf));
            if(professorDelete == null)
            {
                return NotFound();
            }

            _context.Remove(professorDelete);
            _context.SaveChanges();

            return NoContent();

        }
    }
}
