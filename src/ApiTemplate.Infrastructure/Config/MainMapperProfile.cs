using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ApiTemplate.Core.ProjectAggregate;
using ApiTemplate.Infrastructure.ApiModels;

namespace ApiTemplate.Infrastructure.Config;
public class MainMapperProfile : Profile
{
  public MainMapperProfile()
  {
    CreateMap<Project, ProjectDTO>().ReverseMap().ForMember(dto => dto.Items, config => config.MapFrom(entity => entity.Items));
    CreateMap<ToDoItem, ToDoItemDTO>().ReverseMap();
  }
}
