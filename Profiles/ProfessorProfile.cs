using AutoMapper;
using ProjetoIntegrador.Data.Dtos.ProfessorDtos;
using ProjetoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Profiles
{
    public class ProfessorProfile : Profile
    {
        public ProfessorProfile()
        {
            CreateMap<CreateProfessorDto, Professor>();
            CreateMap<Professor, ReadProfessorDto>()
                .ForMember(professor => professor.Aulas, opts => opts
                .MapFrom(professor => professor.Aulas.Select
                (aula => new { aula.Id, aula.DataInicio, aula.DataFinal, aula.Status })));
            CreateMap<Professor, ReadProfessorDto>()
                .ForMember(professor => professor.Pendencias, opts => opts
                .MapFrom(professor => professor.Pendencias.Select
                (pendencia => new { pendencia.Id, pendencia.Aluno, pendencia.Status })));
            CreateMap<UpdateProfessorDto, Professor>();
        }
    }
}
