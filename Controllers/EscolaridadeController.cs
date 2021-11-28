using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Data;
using ProjetoIntegrador.Data.Dtos.EscolaridadeDtos;
using ProjetoIntegrador.Enumns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EscolaridadeController : ControllerBase
    {
        private MainContext _context;
        private IMapper _mapper;
        public EscolaridadeController(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddEscolaridade([FromBody] CreateEscolaridadeDto escolaridadeDto)
        {
            try
            {
                Escolaridade newEscolaridade = _mapper.Map<Escolaridade>(escolaridadeDto);
                _context.Escolaridades.Add(newEscolaridade);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetEscolaridadeById), new { newEscolaridade.Id }, newEscolaridade);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
        [HttpGet]
        public IEnumerable<Escolaridade> GetEscolaridades()
        {
            return _context.Escolaridades;
        }
        [HttpGet("{id}")]
        public IActionResult GetEscolaridadeById(int id)
        {
            try
            {
                Escolaridade getEscolaridade = _context.Escolaridades.FirstOrDefault(getEscolaridade => getEscolaridade.Id == id);

                if (getEscolaridade != null)
                {
                    ReadEscolaridadeDto escolaridadeDto = _mapper.Map<ReadEscolaridadeDto>(getEscolaridade);

                    return Ok(escolaridadeDto);
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
