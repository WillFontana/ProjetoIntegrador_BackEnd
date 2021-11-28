using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Data.Dtos.MateriaDtos
{
    public class UpdateAulaDto
    {
        // ---- Data Inicial
        [Required(ErrorMessage = "A data inicial é um campo obrigatorio")]
        public string dataInicio { get; set; }
        // --- Data Final
        [Required(ErrorMessage = "A data final é um campo obrigatorio")]
        public string dataFinal { get; set; }
        // --- Remarcada
        [Required(ErrorMessage = "O remarque é um campo obrigatório")]
        public bool remarque { get; set; }
        // -- status 
        [Required(ErrorMessage = "O status é um campo obrigatorio")]
        public string status { get; set; }
    }
}
