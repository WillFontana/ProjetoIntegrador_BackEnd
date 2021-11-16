using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Data.Dtos.EscolaridadeDtos
{
    public class CreateEscolaridadeDto
    {
        // ------------------------------ Codigo
        [Required(ErrorMessage = "O Código é obrigatório!")]
        [MaxLength(255, ErrorMessage = "O valor para o código inserido é muito grande!")]
        public string Codigo { get; set; }
        // ------------------------------ Descrição
        [Required(ErrorMessage = "A Descrição é obrigatório!")]
        [MaxLength(255, ErrorMessage = "O valor para a Descrição inserido é muito grande!")]
        public string Descricao { get; set; }
    }
}
