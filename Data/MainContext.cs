using Microsoft.EntityFrameworkCore;
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
            builder.Entity<Professor>().HasIndex(professor => professor.Crn).IsUnique();
            builder.Entity<Aluno>().HasIndex(aluno => aluno.Cpf).IsUnique();
            builder.Entity<Aula>().HasOne(aula => aula.Professor).WithMany(professor => professor.Aulas).HasForeignKey(aula => aula.ProfessorId);
            builder.Entity<Aula>().HasOne(aula => aula.Aluno).WithMany(aluno => aluno.Aulas).HasForeignKey(aula => aula.AlunoId);
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
