﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegrador.Data;
using ProjetoIntegrador.Data.Dtos.AlunoDto;
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
    public class AlunoController : ControllerBase
    {
        private MainContext _context;
        private IMapper _mapper;
        public AlunoController(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IEnumerable<Aluno> GetAlunos()
        {
            return _context.Alunos;
        }
        [HttpGet("{cpf}")]
        public IActionResult GetalunoGetByCpf(string cpf)
        {
            Aluno alunoGet = _context.Alunos.FirstOrDefault(alunoGet => alunoGet.Cpf.Equals(cpf));

            if (alunoGet != null)
            {
                ReadAlunoDto alunoDto = _mapper.Map<ReadAlunoDto>(alunoGet);

                return Ok(alunoDto);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult AddAluno([FromBody] CreateAlunoDto alunoDto)
        {
            Aluno newAluno = _mapper.Map<Aluno>(alunoDto);

            _context.Alunos.Add(newAluno);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetalunoGetByCpf), new { newAluno.Cpf }, newAluno);
        }
        [HttpPut("{cpf}")]
        public IActionResult UpdateAluno(string cpf, [FromBody] UpdateAlunoDto alunoDto)
        {
            Aluno alunoUpdate = _context.Alunos.FirstOrDefault(alunoUpdate => alunoUpdate.Cpf.Equals(cpf));

            if (alunoUpdate == null)
            {
                return NotFound();
            }
            _mapper.Map(alunoDto, alunoUpdate);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{cpf}")]
        public IActionResult DeleteProfessor(string cpf)
        {
            Aluno alunoDelete = _context.Alunos.FirstOrDefault(alunoDelete => alunoDelete.Cpf.Equals(cpf));
            if (alunoDelete == null)
            {
                return NotFound();
            }

            _context.Remove(alunoDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
