using AutoMapper;
using GISA.Convenio.API.Models;

namespace GISA.Convenio.API.Configuration.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Domain.Convenio, ConvenioViewModel>().ReverseMap();
            CreateMap<Domain.Endereco, EnderecoViewModel>().ReverseMap();
        }
    }
}
