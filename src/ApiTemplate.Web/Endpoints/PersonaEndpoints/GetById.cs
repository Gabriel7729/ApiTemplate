using ApiTemplate.Core.Entities.PersonaAggregate;
using ApiTemplate.Core.Entities.PersonaAggregate.Specs;
using ApiTemplate.Infrastructure.Dto.PersonaDtos;
using ApiTemplate.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.PersonaEndpoints;

public class GetById : EndpointBaseAsync
      .WithRequest<Guid>
      .WithActionResult<PersonaResponseDto>
{
  private readonly IRepository<Persona> _repository;
  private readonly IMapper _mapper;

  public GetById(IRepository<Persona> repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  [HttpGet("/Persona/{personaId:guid}")]
  [SwaggerOperation(
      Summary = "List all Personas",
      Description = "List all Personas",
      OperationId = "Persona.GetById",
      Tags = new[] { "PersonaEndpoints" })
  ]
  public override async Task<ActionResult<PersonaResponseDto>> HandleAsync([FromRoute] Guid personaId,
      CancellationToken cancellationToken)
  {
    try
    {
      GetPersonaaWithEventosSpec spec = new(personaId);
      Persona? persona = await _repository.GetBySpecAsync(spec, cancellationToken);
      if (persona is null)
        return NotFound(Result<PersonaResponseDto>.Error("Persona not found"));

      PersonaResponseDto personaResponseDto = _mapper.Map<PersonaResponseDto>(persona);
      var result = Result<PersonaResponseDto>.Success(personaResponseDto);

      return Ok(result);
    }
    catch (Exception ex)
    {
      return BadRequest(Result<PersonaResponseDto>.Error(ex.Message));
    }
  }
}

