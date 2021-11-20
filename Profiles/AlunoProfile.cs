using AutoMapper;
using ProjetoIntegrador.Data.Dtos.AlunoDto;
using ProjetoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Profiles
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            CreateMap<CreateAlunoDto, Aluno>();
            CreateMap<Aluno, ReadAlunoDto>()
                .ForMember(aluno => aluno.Aulas, opts => opts
                .MapFrom(aluno => aluno.Aulas.Select
                (aula => new { aula.Id, aula.DataInicio, aula.DataFinal, aula.Status })));
            CreateMap<UpdateAlunoDto, Aluno>();
        }
    }
}
