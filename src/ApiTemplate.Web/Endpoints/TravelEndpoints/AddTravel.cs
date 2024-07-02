using ApiTemplate.Core.Entities.TravelAggregate;
using ApiTemplate.Infrastructure.Dto.TravelDtos;
using ApiTemplate.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.TravelEndpoints;

public class Create : EndpointBaseAsync
      .WithRequest<TravelDto>
      .WithActionResult<TravelResponseDto>
{
  private readonly IRepository<Travel> _repository;
  private readonly IMapper _mapper;

  public Create(IRepository<Travel> repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  [HttpPost("/Travel")]
  [SwaggerOperation(
      Summary = "Creates a new Travel",
      Description = "Creates a new Travel",
      OperationId = "Travel.Create",
      Tags = new[] { "TravelEndpoints" })
  ]
  public override async Task<ActionResult<TravelResponseDto>> HandleAsync(TravelDto request,
      CancellationToken cancellationToken)
  {
    try
    {
      Travel vehiculo = _mapper.Map<Travel>(request);
      Travel responseEntity = await _repository.AddAsync(vehiculo, cancellationToken);

      TravelResponseDto responseTravelDto = _mapper.Map<TravelResponseDto>(responseEntity);
      return Ok(Result<TravelResponseDto>.Success(responseTravelDto));
    }
    catch (Exception ex)
    {
      return BadRequest(Result<TravelResponseDto>.Error(ex.Message));
    }
  }
}


