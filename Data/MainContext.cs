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

        public DbSet<Professor> Professores { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Pendencia> Pendencias { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Grau> Graus { get; set; }
        public DbSet<Escolaridade> Escolaridades { get; set; }
    }
}
