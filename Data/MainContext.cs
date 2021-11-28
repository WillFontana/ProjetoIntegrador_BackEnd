using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Enumns;
using ProjetoIntegrador.JoinEntities;
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
            builder.Entity<Professor>().HasIndex(professor => professor.Cpf).IsUnique();
            builder.Entity<Aluno>().HasIndex(aluno => aluno.Cpf).IsUnique();
            builder.Entity<Usuario>().HasIndex(usuario => usuario.Crn).IsUnique();
            // Relacionaments 1-n (Enuns)
            // O professor tem um grau, que possui vários professores, que possuírem o id desse grau
            builder.Entity<Professor>().HasOne(professor => professor.Grau).WithMany(grau => grau.Professores).HasForeignKey(professor => professor.GrauId);
            builder.Entity<Aluno>().HasOne(aluno => aluno.Escolaridade).WithMany(escolaridade => escolaridade.Alunos).HasForeignKey(aluno => aluno.EscolaridadeId);
            // Relacionamentos 1-n (aulas)
            builder.Entity<Aula>().HasOne(aula => aula.Professor).WithMany(professor => professor.Aulas).HasForeignKey(aula => aula.ProfessorId);
            builder.Entity<Aula>().HasOne(aula => aula.Aluno).WithMany(aluno => aluno.Aulas).HasForeignKey(aula => aula.AlunoId);
            builder.Entity<Aula>().HasOne(aula => aula.Materia).WithMany(materia => materia.Aulas).HasForeignKey(aula => aula.MateriaId);
            // Relacionamentos n-n (professor e matérias)
            // O vinculo de materias e professores tem um professor, com várias matérias ensinadas pelo professor que possuirem seu id.
            builder.Entity<MateriasPorProfessor>().HasOne(mpp => mpp.Professor).WithMany(professor => professor.MateriasDadas).HasForeignKey(mpp => mpp.ProfessorId);
            // O vinculo de materias e professores tem uma matéria, com vários professores que ensinam que possuirem o id da matéria.
            builder.Entity<MateriasPorProfessor>().HasOne(mpp => mpp.Materia).WithMany(materia => materia.ProfessoresQueEnsinam).HasForeignKey(mpp => mpp.MateriaId);
            // Relacionamentos 1-n (Pendencias)
            builder.Entity<Pendencia>().HasOne(pendencia => pendencia.Professor).WithMany(professor => professor.Pendencias).HasForeignKey(pendencia => pendencia.ProfessorId);
            builder.Entity<Pendencia>().HasOne(pendencia => pendencia.Aluno).WithMany(aluno => aluno.Pendencias).HasForeignKey(pendencia => pendencia.AlunoId);
        }
        public DbSet<Professor> Professores { get; set; }
        
        // Seta a listagem de matérias a partir da tabela de matérias do DB
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Pendencia> Pendencias { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Grau> Graus { get; set; }
        public DbSet<Escolaridade> Escolaridades { get; set; }
        public DbSet<MateriasPorProfessor> MateriasPorProfessors { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
