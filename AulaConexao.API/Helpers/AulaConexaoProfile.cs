using AutoMapper;
using Models.AulaConexao.Domain;
using AulaConexao.API.Dto;
using AulaConexao.Domain.Models;

namespace AulaConexao.API.Helpers
{
    public class AulaConexaoProfile : Profile
    {
        public AulaConexaoProfile()
        {
            CreateMap<Professor, ProfessorDto>()
                .ForMember(dest => dest.Turno, opt => opt.ToString());

            CreateMap<TurmaProfessor, TurmaProfessorDto>()
                .ForMember(dest => dest.Turma, opt => opt.MapFrom(src => src.Turma.Nome))
                .ForMember(dest => dest.Professor, opt => opt.MapFrom(src => src.Professor.Nome));

            CreateMap<AlunoTurma, AlunoTurmaDto>()
               .ForMember(dest => dest.Aluno, opt => opt.MapFrom(src => src.Aluno.Nome))
               .ForMember(dest => dest.Turma, opt => opt.MapFrom(src => src.Turma.Nome));

            CreateMap<Turma, TurmaDto>();              
        }
    }
}
