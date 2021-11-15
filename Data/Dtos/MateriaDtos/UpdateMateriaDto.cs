using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Data.Dtos.MateriaDtos
{
    public class UpdateMateriaDto
    {
        // ------------------------------ Nome
        [Required(ErrorMessage = "O nome é um campo obrigatório!")]
        [MinLength(3, ErrorMessage = "O nome inserido não é valido!")]
        [MaxLength(255, ErrorMessage = "O valor inserido é muito grande para o nome!")]
        public string Nome { get; set; }
    }
}
