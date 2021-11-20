using AutoMapper;
using ProjetoIntegrador.Data.Dtos.MateriasPorProfessorDto;
using ProjetoIntegrador.JoinEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Profiles
{
    public class MateriasPorProfessorProfile : Profile
    {
        public MateriasPorProfessorProfile()
        {
            CreateMap<CreateMateriasPorProfessorDto, MateriasPorProfessor>();
            CreateMap<MateriasPorProfessor, ReadMateriasPorProfessorDto>();
        }
    }
}
