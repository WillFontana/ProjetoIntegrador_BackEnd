using AutoMapper;
using ProjetoIntegrador.Data.Dtos.UsuarioDtos;
using ProjetoIntegrador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Profiles
{
    public class UsuarioProfile : Profile
    {
       public UsuarioProfile()
        {
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
