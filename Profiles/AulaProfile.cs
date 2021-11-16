using AutoMapper;
using ProjetoIntegrador.Data.Dtos.MateriaDtos;
using ProjetoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Profiles
{
    public class AulaProfile : Profile
    {
       public AulaProfile()
        {
            CreateMap<CreateAulaDto, Materia>();
            CreateMap<Materia, ReadAulaDto> ();
            CreateMap<UpdateAulaDto, Materia>();
        }
    }
}
