using ApiTemplate.Core.Entities.CarfaxAggregate;
using ApiTemplate.Core.Entities.CarfaxAggregate.Specs;
using ApiTemplate.Infrastructure.Dto.VehiculoDtos;
using ApiTemplate.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.VehiculoEndpoints;

public class GetById : EndpointBaseAsync
      .WithRequest<Guid>
      .WithActionResult<VehiculoResponseDto>
{
  private readonly IRepository<Vehiculo> _repository;
  private readonly IMapper _mapper;

  public GetById(IRepository<Vehiculo> repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  [HttpGet("/Vehiculos/{vehiculo:guid}")]
  [SwaggerOperation(
      Summary = "List all Vehiculos",
      Description = "List all Vehiculos",
      OperationId = "Vehiculo.ListPaginated",
      Tags = new[] { "VehiculoEndpoints" })
  ]
  public override async Task<ActionResult<VehiculoResponseDto>> HandleAsync(Guid vehiculoId,
      CancellationToken cancellationToken)
  {
    try
    {
      GetVehiculoWithEventosSpec spec = new(vehiculoId);
      Vehiculo? vehiculo = await _repository.GetBySpecAsync(spec, cancellationToken);
      if (vehiculo is null)
        return NotFound(Result<VehiculoResponseDto>.Error("Vehiculo not found"));

      VehiculoResponseDto vehiculoResponseDto = _mapper.Map<VehiculoResponseDto>(vehiculo);
      var result = Result<VehiculoResponseDto>.Success(vehiculoResponseDto);

      return Ok(result);
    }
    catch (Exception ex)
    {
      return BadRequest(Result<VehiculoResponseDto>.Error(ex.Message));
    }
  }
}

