using AutoMapper;
using CleanArch.Application.Dtos;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.AutomapperConfig
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Funcionario, FuncionarioDto>().ReverseMap();
            CreateMap<CreateFuncionarioDto, Funcionario>().ReverseMap();
            CreateMap<UpdateFuncionarioDto, Funcionario>().ReverseMap();
        }
    }
}
