using ProjetoIntegrador.JoinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Models
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }
        //------------------------------NOME
        [Required(ErrorMessage = "O nome é um campo obrigatório")]
        [MaxLength(255, ErrorMessage = "O nome inserido não é valido")]
        [MinLength(5, ErrorMessage = "O nome inserido não é valido")]
        public string Nome { get; set; }
        // -- Relacionamento com varias aulas
        [JsonIgnore]
        public virtual List<Aula> Aulas { get; set; }
        // Lista de vinculos de matéria por professor
        public virtual List<MateriasPorProfessor> ProfessoresQueEnsinam { get; set; }
    }

}
