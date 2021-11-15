using AutoMapper;
using ProjetoIntegrador.Data.Dtos.GrauDtos;
using ProjetoIntegrador.Enumns;

namespace ProjetoIntegrador.Profiles
{
    public class GrauProfille : Profile
    {
        public GrauProfille()
        {
            CreateMap<CreateGrauDto, Grau>();
            CreateMap<Grau, ReadGrauDto>();
        }
    }
}

