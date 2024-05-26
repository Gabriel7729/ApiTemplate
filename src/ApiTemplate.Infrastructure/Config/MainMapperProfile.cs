using ApiTemplate.Core.Entities.PersonaAggregate;
using ApiTemplate.Infrastructure.Dto.PersonaDtos;
using AutoMapper;

namespace ApiTemplate.Infrastructure.Config;
public class MainMapperProfile : Profile
{
  public MainMapperProfile()
  {
    CreateMap<Persona, PersonaDto>().ReverseMap();
    CreateMap<Persona, PersonaResponseDto>().ReverseMap();

    CreateMap<PersonaEvento, PersonaEventoDto>().ReverseMap();
    CreateMap<PersonaEvento, PersonaEventoResponseDto>().ReverseMap();
  }
}
