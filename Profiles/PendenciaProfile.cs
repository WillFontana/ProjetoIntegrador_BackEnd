using AutoMapper;
using ProjetoIntegrador.Data.Dtos.PendenciaDtos;
using ProjetoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Profiles
{
    public class PendenciaProfile : Profile
    {
        public PendenciaProfile()
        {
            CreateMap<CreatePendenciaDto, Pendencia>();
            CreateMap<Pendencia, ReadPendenciaDto>();
            CreateMap<UpdatePendenciaDto, Pendencia>();
        }
    }
}
