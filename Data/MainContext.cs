﻿using Microsoft.EntityFrameworkCore;
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
    }
}
