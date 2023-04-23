using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LabSchoolApi.Models;
using LabSchoolApi.DTOs;
using LabSchoolApi.Models.Enums;

namespace LabSchoolApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Aluno, AlunoDTO>()
                .ForMember(dest => dest.Situacao, opt => opt.MapFrom(src => Enum.GetName(typeof(SituacaoMatricula), src.SituacaoMatricula)))
                .ForMember(dest => dest.Atendimentos, opt => opt.MapFrom(src => src.QuantidadeAtendimentosPedagogicos));
                
            CreateMap<AlunoDTO, Aluno>()
                .ForMember(dest => dest.SituacaoMatricula, opt => opt.MapFrom(src => Enum.Parse<SituacaoMatricula>(src.Situacao)))
                .ForMember(dest => dest.QuantidadeAtendimentosPedagogicos, opt => opt.MapFrom(src => src.Atendimentos));

            CreateMap<Pedagogo, PedagogoDTO>().ReverseMap();
            CreateMap<AtendimentoPedagogico.Request, AtendimentoPedagogicoRequestDTO>().ReverseMap();
            CreateMap<AtendimentoPedagogico.Response, AtendimentoPedagogicoResponseDTO>().ReverseMap();

            CreateMap<Professor, ProfessorDTO>()
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => Enum.GetName(typeof(StatusProfessor), src.Estado)))
                .ReverseMap()
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => Enum.Parse<StatusProfessor>(src.Estado)));
        }
    }
}
