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
            CreateMap<CreateAulaDto, Aula>();
            CreateMap<Aula, ReadAulaDto> ();
            CreateMap<UpdateAulaDto, Aula>();
        }
    }
}
