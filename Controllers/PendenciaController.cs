using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Data;
using ProjetoIntegrador.Data.Dtos.PendenciaDtos;
using ProjetoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PendenciaController : ControllerBase
    {
        private MainContext _context;
        private IMapper _mapper;

        public PendenciaController(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Pendencia> GetPendencias()
        {
            return _context.Pendencias;
        }
        [HttpGet("{codigo}")]
        public IActionResult GetPendenciaById(int codigo)
        {
            Pendencia pendenciaGet = _context.Pendencias.FirstOrDefault(pendenciaGet => pendenciaGet.Codigo == codigo);

            if (pendenciaGet != null)
            {
                ReadPendenciaDto pendenciaDto = _mapper.Map<ReadPendenciaDto>(pendenciaGet);

                return Ok(pendenciaDto);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult AddPendencia([FromBody] CreatePendenciaDto pendenciaDto)
        {
            Pendencia newPendencia = _mapper.Map<Pendencia>(pendenciaDto);

            _context.Pendencias.Add(newPendencia);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPendenciaById), new { newPendencia.Status }, newPendencia);
        }
        [HttpPut("{codigo}")]
        public IActionResult UpdatePendencia(int codigo, [FromBody] UpdatePendenciaDto pendenciaDto)
        {
            Pendencia pendenciaUpdate = _context.Pendencias.FirstOrDefault(pendenciaUpdate => pendenciaUpdate.Codigo == codigo);

            if (pendenciaUpdate == null)
            {
                return NotFound();
            }
            _mapper.Map(pendenciaDto, pendenciaUpdate);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

