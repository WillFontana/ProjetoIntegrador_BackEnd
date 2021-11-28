using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Data;
using ProjetoIntegrador.Data.Dtos.MateriaDtos;
using ProjetoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AulaController : ControllerBase
    {
        private MainContext _context;
        private IMapper _mapper;

        public AulaController(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Aula> GetAulas()
        {
            return _context.Aulas;
        }
        [HttpGet("{id}")]
        public IActionResult GetAulaById(int id)
        {
            try
            {
                Aula aulaGet = _context.Aulas.FirstOrDefault(aulaGet => aulaGet.Id == id);

                if (aulaGet != null)
                {
                    ReadAulaDto aulaDto = _mapper.Map<ReadAulaDto>(aulaGet);

                    return Ok(aulaDto);
                }
                return NotFound();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
        [HttpPost]
        public IActionResult AddAula([FromBody] CreateAulaDto aulaDto)
        {
            try
            {
                Aula newAula = _mapper.Map<Aula>(aulaDto);

                _context.Aulas.Add(newAula);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetAulaById), new { newAula.Id }, newAula);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateAula(int id, [FromBody] UpdateAulaDto aulaDto)
        {
            try
            {
                Aula aulaUpdate = _context.Aulas.FirstOrDefault(aulaUpdate => aulaUpdate.Id == id);

                if (aulaUpdate == null)
                {
                    return NotFound();
                }
                _mapper.Map(aulaDto, aulaUpdate);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
    }
}
