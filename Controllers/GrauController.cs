using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Data;
using ProjetoIntegrador.Data.Dtos.GrauDtos;
using ProjetoIntegrador.Enumns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrauController : ControllerBase
    {
        private MainContext _context;
        private IMapper _mapper;
        public GrauController(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddGrau([FromBody] CreateGrauDto grauDto)
        {
            try
            {
                Grau newGrau = _mapper.Map<Grau>(grauDto);
                _context.Graus.Add(newGrau);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetGrauById), new { newGrau.Id }, newGrau);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
        [HttpGet]
        public IEnumerable<Grau> GetGraus()
        {
            return _context.Graus;
        }
        [HttpGet("{id}")]
        public IActionResult GetGrauById(int id)
        {
            try
            {
                Grau getGrau = _context.Graus.FirstOrDefault(getGrau => getGrau.Id == id);

                if (getGrau != null)
                {
                    ReadGrauDto grauDto = _mapper.Map<ReadGrauDto>(getGrau);

                    return Ok(grauDto);
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
