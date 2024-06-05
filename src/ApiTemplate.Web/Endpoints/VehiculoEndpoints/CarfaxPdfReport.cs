using ApiTemplate.Core.Entities.CarfaxAggregate.Specs;
using ApiTemplate.Core.Entities.CarfaxAggregate;
using ApiTemplate.Infrastructure.Dto.VehiculoDtos;
using ApiTemplate.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ApiTemplate.Core.Interfaces;

namespace ApiTemplate.Web.Endpoints.VehiculoEndpoints;

public class CarfaxPdfReport : EndpointBaseAsync
      .WithRequest<Guid>
      .WithoutResult
{
  private readonly IRepository<Vehiculo> _repository;
  private readonly IVehiculoService _vehiculoService;

  public CarfaxPdfReport(IRepository<Vehiculo> repository, IVehiculoService vehiculoService)
  {
    _repository = repository; 
    _vehiculoService = vehiculoService;
  }

  [HttpPost("/Vehiculos/{vehiculoId:guid}/Carfax/Report")]
  [SwaggerOperation(
      Summary = "Get Carfax Report",
      Description = "Get Carfax Report",
      OperationId = "Vehiculo.Carfax.Report",
      Tags = new[] { "VehiculoEndpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] Guid vehiculoId,
      CancellationToken cancellationToken)
  {
    try
    {
      GetVehiculoWithEventosSpec spec = new(vehiculoId);
      Vehiculo? vehiculo = await _repository.GetBySpecAsync(spec, cancellationToken);
      if (vehiculo is null)
        return NotFound(Result<FileStreamResult>.Error("Vehiculo not found"));

      var file = _vehiculoService.GenerateCarfaxReport(vehiculo);
      return File(file.FileStream, file.ContentType);
    }
    catch (Exception ex)
    {
      return BadRequest(Result<FileStreamResult>.Error(ex.Message));
    }
  }
}
