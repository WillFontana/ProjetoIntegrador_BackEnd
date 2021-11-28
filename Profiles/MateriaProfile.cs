using AutoMapper;
using ProjetoIntegrador.Data.Dtos.MateriaDtos;
using ProjetoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Profiles
{
    public class MateriaProfile : Profile
    {
       public MateriaProfile()
        {
            // Transforma o DTO (data transfer object) da matéria em uma entidade da matéria
            CreateMap<CreateMateriaDto, Materia>();
            // Transforma a entidade da matéria em um DTO
            CreateMap<Materia, ReadMateriaDto>()
                .ForMember(materia => materia.Aulas, opts => opts
                .MapFrom(materia => materia.Aulas.Select
                (aula => new { aula.Id, aula.DataInicio, aula.DataFinal, aula.Status })));
            // Transforma o DTO (data transfer object) da matéria em uma entidade da matéria
            CreateMap<UpdateMateriaDto, Materia>();
        }
    }
}
