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
            CreateMap<Professor, ReadProfessorDto>();
            CreateMap<UpdateProfessorDto, Professor>();
        }
    }
}
