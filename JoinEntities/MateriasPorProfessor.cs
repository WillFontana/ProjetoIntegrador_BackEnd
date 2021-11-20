using ProjetoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjetoIntegrador.JoinEntities
{
    public class MateriasPorProfessor
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [JsonIgnore]
        public virtual Materia Materia { get; set; }
        [JsonIgnore]
        public virtual Professor Professor { get; set; }
        public int MateriaId { get; set; }
        public int ProfessorId { get; set; }
    }
}
