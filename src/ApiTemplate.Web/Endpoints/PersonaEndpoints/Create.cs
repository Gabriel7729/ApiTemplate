using ApiTemplate.Core.Entities.PersonaAggregate;
using ApiTemplate.Infrastructure.Dto.PersonaDtos;
using ApiTemplate.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.PersonaEndpoints;

public class Create : EndpointBaseAsync
      .WithRequest<PersonaDto>
      .WithActionResult<PersonaResponseDto>
{
  private readonly IRepository<Persona> _repository;
  private readonly IMapper _mapper;

  public Create(IRepository<Persona> repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  [HttpPost("/Persona")]
  [SwaggerOperation(
      Summary = "Creates a new Persona",
      Description = "Creates a new Persona",
      OperationId = "Persona.Create",
      Tags = new[] { "PersonaEndpoints" })
  ]
  public override async Task<ActionResult<PersonaResponseDto>> HandleAsync(PersonaDto request,
      CancellationToken cancellationToken)
  {
    try
    {
      Persona vehiculo = _mapper.Map<Persona>(request);
      Persona responseEntity = await _repository.AddAsync(vehiculo, cancellationToken);

      PersonaResponseDto responsePersonaDto = _mapper.Map<PersonaResponseDto>(responseEntity);
      return Ok(Result<PersonaResponseDto>.Success(responsePersonaDto));
    }
    catch (Exception ex)
    {
      return BadRequest(Result<PersonaResponseDto>.Error(ex.Message));
    }
  }
}

