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
    public class MateriaController : ControllerBase 
    {
        private MainContext _context;
        private IMapper _mapper;

        public MateriaController(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Materia> GetMaterias()
        {
            return _context.Materias;
        }
        [HttpGet("{id}")]
        public IActionResult GetMateriaByCodigo(int id)
        {
            Materia materiaGet = _context.Materias.FirstOrDefault(materiaGet => materiaGet.Id == id);

            if(materiaGet != null)
            {
                ReadMateriaDto materiaDto = _mapper.Map<ReadMateriaDto>(materiaGet);

                return Ok(materiaDto);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult AddMateria([FromBody] CreateMateriaDto materiaDto)
        {
            Materia newMateria = _mapper.Map<Materia>(materiaDto);

            _context.Materias.Add(newMateria);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMateriaByCodigo), new { newMateria.Id }, newMateria);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMateria(int id, [FromBody] UpdateMateriaDto materiaDto)
        {
            Materia materiaUpdate = _context.Materias.FirstOrDefault(materiaUpdate => materiaUpdate.Id == id);

            if (materiaUpdate == null)
            {
                return NotFound();
            }
            _mapper.Map(materiaDto, materiaUpdate);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMateria(int id)
        {
            Materia materiaDelete = _context.Materias.FirstOrDefault(materiaDelete => materiaDelete.Id == id);
            if (materiaDelete == null)
            {
                return NotFound();
            }

            _context.Remove(materiaDelete);
            _context.SaveChanges();

            return NoContent();

        }
    }
}
