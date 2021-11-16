﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Models
{
    public class Aula
    {
        // ---- id aula 
        [Key]
        public int Id { get; set; }
        // ---- Data Inicial
        [Required(ErrorMessage ="A data inicial é um campo obrigatorio")]
        public DateTime DataInicio { get; set; }
        // --- Data Final
        [Required(ErrorMessage = "A data final é um campo obrigatorio")]
        public DateTime DataFinal { get; set; }
        // --- Remarcada
        [Required(ErrorMessage = "O remarque é um campo obrigatório")]
        public bool Remarque { get; set; }
        // -- status 
        [Required(ErrorMessage = "O status é um campo obrigatorio")]
        public string Status { get; set; }
    }
}