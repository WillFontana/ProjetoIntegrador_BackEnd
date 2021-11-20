using AutoMapper;
using ProjetoIntegrador.Data.Dtos.EscolaridadeDtos;
using ProjetoIntegrador.Enumns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Profiles
{
    public class EscolaridadeProfile : Profile
    {
        public EscolaridadeProfile()
        {
            CreateMap<CreateEscolaridadeDto, Escolaridade>();
            CreateMap<Escolaridade, ReadEscolaridadeDto>()
                .ForMember(escolaridade => escolaridade.Alunos, opts => opts
                .MapFrom(escolaridade => escolaridade.Alunos.Select
                (aluno => new { aluno.Id, aluno.Cpf, aluno.Nome})));
        }
    }
}
