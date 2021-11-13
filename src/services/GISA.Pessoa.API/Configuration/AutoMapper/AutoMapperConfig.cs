using AutoMapper;
using GISA.Pessoa.API.Models;

namespace GISA.Pessoa.API.Configuration.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Domain.Pessoa, PessoaViewModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Endereco))
                .ForMember(dest => dest.EnderecoViewModel, opt => opt.MapFrom(src => src.Endereco))
                .ReverseMap()
                .ForPath(dest => dest.Email.Endereco, opt => opt.MapFrom(src => src.Email));

            CreateMap<Domain.Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Domain.Plano, PlanoViewModel>().ReverseMap();
            CreateMap<Domain.PlanoCliente, PlanoClienteViewModel>().ReverseMap();
        }
    }
}
