using ApiTemplate.Core.Entities.TravelAggregate;
using Microsoft.AspNetCore.Mvc;

namespace ApiTemplate.Core.Interfaces;
public interface ITravelService
{
  FileStreamResult GenerateTravelReceipt(Travel travel);
}
