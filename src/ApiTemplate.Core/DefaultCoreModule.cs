using ApiTemplate.Core.Interfaces;
using ApiTemplate.Core.Services;
using Autofac;

namespace ApiTemplate.Core;
public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<VehiculoService>().As<IVehiculoService>()
      .InstancePerLifetimeScope();

    builder.RegisterType<OtpService>().As<IOtpService>()
      .InstancePerLifetimeScope();

    builder.RegisterType<TravelService>().As<ITravelService>()
      .InstancePerLifetimeScope();
  }
}
