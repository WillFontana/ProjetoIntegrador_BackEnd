using ProjetoIntegrador.Enumns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Models
{
    public class Aluno
    {
        // ------------------------------ id
        [Key]
        [Required]
        public int Id { get; set; }
        // ------------------------------ Nome
        [Required(ErrorMessage = "O nome é um campo obrigatório!")]
        [MinLength(3, ErrorMessage = "O nome inserido não é valido!")]
        [MaxLength(255, ErrorMessage = "O valor inserido é muito grande para o nome!")]
        public string Nome { get; set; }
        // ------------------------------ CPF
        [Required(ErrorMessage = "O CPF é um campo obrigatório!")]
        [StringLength(11, ErrorMessage = "O CPF inserido não é valido!")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O campo idade é obrigatório!")]
        public int Idade { get; set; }
        [ForeignKey("EscolaridadeId")]
        public virtual Escolaridade Escolaridade { get; set; }
        public int EscolaridadeId { get; set; }
    }
}
