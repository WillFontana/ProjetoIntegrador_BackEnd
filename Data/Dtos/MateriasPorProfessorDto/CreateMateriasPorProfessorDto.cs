using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Data.Dtos.MateriasPorProfessorDto
{
    public class CreateMateriasPorProfessorDto
    {
        [Key]
        public int MateriaId { get; set; }
        public int ProfessorId { get; set; }
    }
}
