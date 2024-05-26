using ApiTemplate.Core.Entities.CarfaxAggregate;
using Microsoft.AspNetCore.Mvc;

namespace ApiTemplate.Core.Interfaces;
public interface IVehiculoService
{
  FileStreamResult GenerateCarfaxReport(Vehiculo vehiculo);
}
