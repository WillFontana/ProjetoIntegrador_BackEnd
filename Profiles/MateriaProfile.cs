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
            CreateMap<CreateMateriaDto, Materia>();
            CreateMap<Materia, ReadMateriaDto>();
            CreateMap<UpdateMateriaDto, Materia>();
        }
    }
}
