using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Models
{
    public class Aula
    {
        // ---- id aula 
        [Key]
        public int Id { get; set; }
        // ---- Data Inicial
        [Required(ErrorMessage ="A data inicial é um campo obrigatorio")]
        public string DataInicio { get; set; }
        // --- Data Final
        [Required(ErrorMessage = "A data final é um campo obrigatorio")]
        public string DataFinal { get; set; }
        // --- Remarcada
        [Required(ErrorMessage = "O remarque é um campo obrigatório")]
        public bool Remarque { get; set; }
        // -- status 
        [Required(ErrorMessage = "O status é um campo obrigatorio")]
        public string Status { get; set; }
        
        // -- Relacionamento com um professor
        public virtual Professor Professor { get; set; }
        public int ProfessorId { get; set; }
        // -- Relacionamento com um aluno
        public virtual Aluno Aluno { get; set; }
        public int AlunoId { get; set; }
        // -- Relacionamento com uma materia
        public virtual Materia Materia { get; set; }
        public int MateriaId { get; set; }
    }
}