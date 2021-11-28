using ProjetoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Enumns
{
    public class Grau
    {
        // ------------------------------ id
        [Key]
        [Required]
        public int Id { get; set; }
        // ------------------------------ Codigo
        [Required(ErrorMessage = "O Código é obrigatório!")]
        [MaxLength(255, ErrorMessage = "O valor para o código inserido é muito grande!")]
        public string Codigo { get; set; }
        // ------------------------------ Descrição
        [Required(ErrorMessage = "A Descrição é obrigatório!")]
        [MaxLength(255, ErrorMessage = "O valor para a Descrição inserido é muito grande!")]
        public string Descricao { get; set; }
        [JsonIgnore]
        // Um grau está presente na formação de vários professores.
        public virtual List<Professor> Professores { get; set; }
    }
}
