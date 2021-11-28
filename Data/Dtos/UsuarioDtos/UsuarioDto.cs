using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Data.Dtos.UsuarioDtos
{
    public class UsuarioDto
    {
        // ------------------------------ CRN
        [Required(ErrorMessage = "O CRN é um campo obrigatório!")]
        public string Crn { get; set; }
        [Required(ErrorMessage = "A senha é um campo obrigatório!")]
        public string Senha { get; set; }
    }
}
