using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegrador.Data.Dtos.GrauDtos
{
    public class ReadGrauDto
    {
        // ------------------------------ id
        [Key]
        public int Id { get; set; }
        // ------------------------------ Codigo
        [Required(ErrorMessage = "O Código é obrigatório!")]
        [MaxLength(255, ErrorMessage = "O valor para o código inserido é muito grande!")]
        public string Codigo { get; set; }
        // ------------------------------ Descrição
        [Required(ErrorMessage = "A Descrição é obrigatório!")]
        [MaxLength(255, ErrorMessage = "O valor para a Descrição inserido é muito grande!")]
        public string Descricao { get; set; }
        // -- Professores
        public object Professores { get; set; }
    }
}
