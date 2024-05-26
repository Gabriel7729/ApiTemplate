using ApiTemplate.Core.Entities.CarfaxAggregate;
using ApiTemplate.Infrastructure.Dto.VehiculoDtos;
using AutoMapper;

namespace ApiTemplate.Infrastructure.Config;
public class MainMapperProfile : Profile
{
  public MainMapperProfile()
  {
    CreateMap<Vehiculo, VehiculoDto>().ReverseMap();
    CreateMap<Vehiculo, VehiculoResponseDto>().ReverseMap();

    CreateMap<VehiculoEvento, VehiculoEventoDto>().ReverseMap();
    CreateMap<VehiculoEvento, VehiculoEventoResponseDto>().ReverseMap();
  }
}
