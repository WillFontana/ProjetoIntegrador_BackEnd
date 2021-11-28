using AutoMapper;
using ProjetoIntegrador.Data.Dtos.GrauDtos;
using ProjetoIntegrador.Enumns;
using System.Linq;

namespace ProjetoIntegrador.Profiles
{
    public class GrauProfille : Profile
    {
        public GrauProfille()
        {
            CreateMap<CreateGrauDto, Grau>();
            // Cria uma lista de professores, em que cada objeto tem o id, o crn e o nome desse professor
            CreateMap<Grau, ReadGrauDto>()
                .ForMember(grau => grau.Professores, opts => opts
                .MapFrom(grau => grau.Professores.Select
                (professor => new { professor.Id, professor.Crn, professor.Nome })));
        }
    }
}

