using AutoMapper;
using Caixinhas.Application.DTOS;
using Caixinhas.Domain.Entities;

namespace Caixinhas.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Caixa, CaixaDTO>().ReverseMap();
            CreateMap<CaixaLancamento, CaixaLancamentoDTO>().ReverseMap();  
        }
    }
}
