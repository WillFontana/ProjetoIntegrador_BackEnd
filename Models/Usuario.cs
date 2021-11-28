using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Models
{
    public class Usuario
    {
        // id Usuario
        [Key]
        [Required]
        public int Id { get; set; }
        // Senha
        [Required(ErrorMessage = "A Senha é um campo obrigatório!")]
        public string Senha { get; set; }
        // Crn
        [Required(ErrorMessage = "O CRN é um campo obrigatório!")]
        [StringLength(16, ErrorMessage = "O CRN inserido não é valido!")]
        public string Crn { get; set; }
    }
}