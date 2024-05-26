using ApiTemplate.Core.Entities.CarfaxAggregate;
using ApiTemplate.Infrastructure.Dto.VehiculoDtos;
using ApiTemplate.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.VehiculoEndpoints;

public class Create : EndpointBaseAsync
      .WithRequest<VehiculoDto>
      .WithActionResult<VehiculoResponseDto>
{
  private readonly IRepository<Vehiculo> _repository;
  private readonly IMapper _mapper;

  public Create(IRepository<Vehiculo> repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  [HttpPost("/Vehiculos")]
  [SwaggerOperation(
      Summary = "Creates a new Vehiculo",
      Description = "Creates a new Vehiculo",
      OperationId = "Vehiculo.Create",
      Tags = new[] { "VehiculoEndpoints" })
  ]
  public override async Task<ActionResult<VehiculoResponseDto>> HandleAsync(VehiculoDto request,
      CancellationToken cancellationToken)
  {
    try
    {
      Vehiculo vehiculo = _mapper.Map<Vehiculo>(request);
      Vehiculo responseEntity = await _repository.AddAsync(vehiculo, cancellationToken);

      VehiculoResponseDto responseVehiculoDto = _mapper.Map<VehiculoResponseDto>(responseEntity);
      return Ok(Result<VehiculoResponseDto>.Success(responseVehiculoDto));
    }
    catch (Exception ex)
    {
      return BadRequest(Result<VehiculoResponseDto>.Error(ex.Message));
    }
  }
}

