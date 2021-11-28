using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Data;
using ProjetoIntegrador.Data.Dtos.UsuarioDtos;
using ProjetoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private MainContext _context;
        private IMapper _mapper;
        public UsuarioController(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult validaProfessor([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                Usuario usuario = _context.Usuarios.FirstOrDefault(professorGet => professorGet.Crn.Equals(usuarioDto.Crn));

                if (!(usuarioDto.Senha == usuario.Senha))
                {
                    return Unauthorized();
                }

                UsuarioDto usuarioRetoro = _mapper.Map<UsuarioDto>(usuario);

                return Ok(usuarioRetoro);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
    }
}
