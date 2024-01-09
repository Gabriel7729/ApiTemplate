using Autofac;
using ApiTemplate.Core.Interfaces;
using ApiTemplate.Core.Services;

namespace ApiTemplate.Core;
public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
