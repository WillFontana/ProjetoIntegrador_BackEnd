﻿using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Enumns;
using ProjetoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Chaves unicas
            builder.Entity<Professor>().HasIndex(professor => professor.Crn).IsUnique();
            builder.Entity<Aluno>().HasIndex(aluno => aluno.Cpf).IsUnique();
            // Relacionaments 1-n (Enuns)
            builder.Entity<Professor>().HasOne(professor => professor.Grau).WithMany(grau => grau.Professores).HasForeignKey(professor => professor.GrauId);
            builder.Entity<Aluno>().HasOne(aluno => aluno.Escolaridade).WithMany(escolaridade => escolaridade.Alunos).HasForeignKey(aluno => aluno.EscolaridadeId);
            // Relacionamentos 1-n (aulas)
            builder.Entity<Aula>().HasOne(aula => aula.Professor).WithMany(professor => professor.Aulas).HasForeignKey(aula => aula.ProfessorId);
            builder.Entity<Aula>().HasOne(aula => aula.Aluno).WithMany(aluno => aluno.Aulas).HasForeignKey(aula => aula.AlunoId);
            builder.Entity<Aula>().HasOne(aula => aula.Materia).WithMany(materia => materia.Aulas).HasForeignKey(aula => aula.MateriaId);
            // Relacionamentos n-n (professor e matérias)
            
            // Relacionamentos 1-n (Pendencias)
        }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Pendencia> Pendencias { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Grau> Graus { get; set; }
        public DbSet<Escolaridade> Escolaridades { get; set; }
    }
}
