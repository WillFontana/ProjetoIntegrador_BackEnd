using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Data;
using ProjetoIntegrador.Data.Dtos.MateriasPorProfessorDto;
using ProjetoIntegrador.JoinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnsinoController : ControllerBase
    {
        private MainContext _context;
        private IMapper _mapper;

        public EnsinoController(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddEnsino([FromBody] CreateMateriasPorProfessorDto ensinoDto)
        {
            try
            {
                MateriasPorProfessor ensino = _mapper.Map<MateriasPorProfessor>(ensinoDto);
                _context.MateriasPorProfessors.Add(ensino);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetEnsinoById), new { ensino.Id }, ensino);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
        [HttpGet]
        public IEnumerable<MateriasPorProfessor> GetEnsinos()
        {
            return _context.MateriasPorProfessors;
        }
        [HttpGet("{id}")]
        public IActionResult GetEnsinoById(int id)
        {
            try
            {
                MateriasPorProfessor ensinoGet = _context.MateriasPorProfessors.FirstOrDefault(ensinoGet => ensinoGet.Id == id);

                if (ensinoGet != null)
                {
                    ReadMateriasPorProfessorDto ensinoGetDto = _mapper.Map<ReadMateriasPorProfessorDto>(ensinoGet);
                    return Ok(ensinoGet);
                }
                return NotFound();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
    }
}
