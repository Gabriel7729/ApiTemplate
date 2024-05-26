using ApiTemplate.Core.Entities.CarfaxAggregate;
using ApiTemplate.Infrastructure.Dto.VehiculoDtos;
using ApiTemplate.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.VehiculoEndpoints;

public class AddEvent : EndpointBaseAsync
      .WithRequest<VehiculoEventoDto>
      .WithActionResult<VehiculoEventoResponseDto>
{
  private readonly IRepository<Vehiculo> _repository;
  private readonly IRepository<VehiculoEvento> _vehiculoEventoRepository;
  private readonly IMapper _mapper;

  public AddEvent(IRepository<Vehiculo> repository, IMapper mapper, IRepository<VehiculoEvento> vehiculoEventoRepository)
  {
    _repository = repository;
    _mapper = mapper;
    _vehiculoEventoRepository = vehiculoEventoRepository;
  }

  [HttpPost("/Vehiculos/Eventos")]
  [SwaggerOperation(
      Summary = "Creates a new Vehiculo",
      Description = "Creates a new Vehiculo",
      OperationId = "VehiculoEvent.Create",
      Tags = new[] { "VehiculoEndpoints" })
  ]
  public override async Task<ActionResult<VehiculoEventoResponseDto>> HandleAsync(VehiculoEventoDto request,
      CancellationToken cancellationToken)
  {
    try
    {
      Vehiculo? vehiculo = await _repository.GetByIdAsync(request.VehiculoId, cancellationToken);
      if (vehiculo is null)
        return BadRequest(Result<VehiculoEventoResponseDto>.Error("Vehiculo no encontrado"));

      VehiculoEvento vehiculoEvento = _mapper.Map<VehiculoEvento>(request);
      VehiculoEvento responseEntity = await _vehiculoEventoRepository.AddAsync(vehiculoEvento, cancellationToken);

      VehiculoEventoResponseDto responseVehiculoDto = _mapper.Map<VehiculoEventoResponseDto>(responseEntity);
      return Ok(Result<VehiculoEventoResponseDto>.Success(responseVehiculoDto));
    }
    catch (Exception ex)
    {
      return BadRequest(Result<VehiculoEventoResponseDto>.Error(ex.Message));
    }
  }
}

