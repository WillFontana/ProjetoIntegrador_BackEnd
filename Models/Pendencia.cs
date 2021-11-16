﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Models
{
    public class Pendencia
    {
        [Key]
        public int Id { get; set; }
        //-------------------------------Valor
        [Required(ErrorMessage = "O nome é um campo obrigatório")]
        [MinLength(3, ErrorMessage = "O nome inserido não é valido")]
        public double Valor { get; set; }
        // ------------------------------ Status
        [Required(ErrorMessage = "A Pendencia é um campo obrigatório")]
        [StringLength(255, ErrorMessage = "O Valor inserido é muito grande")]
        public string Status { get; set; }
    }
}
