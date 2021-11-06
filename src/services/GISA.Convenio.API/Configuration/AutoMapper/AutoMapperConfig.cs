using AutoMapper;
using GISA.Convenio.API.Models;
using GISA.Core.DomainObjects;

namespace GISA.Convenio.API.Configuration.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Domain.Convenio, ConvenioViewModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Endereco))
                .ForMember(dest => dest.EnderecoViewModel, opt => opt.MapFrom(src => src.Endereco))
                .ReverseMap()
                .ForPath(dest => dest.Email.Endereco, opt => opt.MapFrom(src => src.Email));

            CreateMap<Domain.Endereco, EnderecoViewModel>().ReverseMap();
        }
    }
}
