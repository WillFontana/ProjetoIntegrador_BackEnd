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
            CreateMap<Materia, ReadAlunoDto>();
            CreateMap<UpdateAlunoDto, Materia>();
        }
    }
}
