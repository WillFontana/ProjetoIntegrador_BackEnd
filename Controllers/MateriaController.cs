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
            try
            {
                // Busca a matéria no banco com o ID passado
                Materia materiaGet = _context.Materias.FirstOrDefault(materiaGet => materiaGet.Id == id);

                if (materiaGet != null)
                {
                    // Cria um objeto de transferência (DTO)
                    ReadMateriaDto materiaDto = _mapper.Map<ReadMateriaDto>(materiaGet);

                    // Retorna para o front end
                    return Ok(materiaDto);
                }
                return NotFound();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }

        }
        [HttpPost]
        public IActionResult AddMateria([FromBody] CreateMateriaDto materiaDto)
        {
            try
            {
                // Cria no Back (API) de dados uma linha na tabela matéria com os dados do nosso objeto de transferência
                Materia newMateria = _mapper.Map<Materia>(materiaDto);

                // Acessa a tabela de matérias e adiciona a nova matéria criada acima
                _context.Materias.Add(newMateria);
                // Ele salva as alterações
                _context.SaveChanges();

                // Executa a função de pegar a matéria pelo id #linha 32 e retorna essa materia a partir do id da matéria criada
                return CreatedAtAction(nameof(GetMateriaByCodigo), new { newMateria.Id }, newMateria);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMateria(int id, [FromBody] UpdateMateriaDto materiaDto)
        {
            try
            {
                // Busca a matéria no banco com o ID passado
                Materia materiaUpdate = _context.Materias.FirstOrDefault(materiaUpdate => materiaUpdate.Id == id);
                if (materiaUpdate == null)
                {
                    return NotFound();
                }
                // Atualiza os dados dessa matéria com o que veio do front
                _mapper.Map(materiaDto, materiaUpdate);
                // Salva as alterações
                _context.SaveChanges();
                // Retorna um Ok
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMateria(int id)
        {
            try
            {
                // Busca a matéria no banco com o ID passado
                Materia materiaDelete = _context.Materias.FirstOrDefault(materiaDelete => materiaDelete.Id == id);
                if (materiaDelete == null)
                {
                    return NotFound();
                }
                // Remove a matéria do banco
                _context.Remove(materiaDelete);
                // Salva as alterações

                _context.SaveChanges();
                // Retorna um Ok
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
