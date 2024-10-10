namespace TechChallangeFase01.Application.Mappings;
using AutoMapper;
using TechChallangeFase01.Application.Dto;
using TechChallangeFase01.Domain.Entities;

public class DtoToEntityMap : Profile
{
    public DtoToEntityMap()
    {
        CreateMap<Contato, ContatoDto>();
        CreateMap<ContatoDto, Contato>();
    }
}
    