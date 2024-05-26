using ApiTemplate.Core.Entities.PersonaAggregate;
using ApiTemplate.Infrastructure.Dto.PersonaDtos;
using ApiTemplate.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.PersonaEndpoints;

public class AddEvent : EndpointBaseAsync
      .WithRequest<PersonaEventoDto>
      .WithActionResult<PersonaEventoResponseDto>
{
  private readonly IRepository<Persona> _repository;
  private readonly IRepository<PersonaEvento> _personaEventoRepository;
  private readonly IMapper _mapper;

  public AddEvent(IRepository<Persona> repository, IMapper mapper, IRepository<PersonaEvento> personaEventoRepository)
  {
    _repository = repository;
    _mapper = mapper;
    _personaEventoRepository = personaEventoRepository;
  }

  [HttpPost("/Persona/Evento")]
  [SwaggerOperation(
      Summary = "Creates a new Persona",
      Description = "Creates a new Persona",
      OperationId = "PersonaEvent.Create",
      Tags = new[] { "PersonaEndpoints" })
  ]
  public override async Task<ActionResult<PersonaEventoResponseDto>> HandleAsync(PersonaEventoDto request,
      CancellationToken cancellationToken)
  {
    try
    {
      Persona? persona = await _repository.GetByIdAsync(request.PersonaId, cancellationToken);
      if (persona is null)
        return BadRequest(Result<PersonaEventoResponseDto>.Error("Persona no encontrado"));

      PersonaEvento personaEvento = _mapper.Map<PersonaEvento>(request);
      PersonaEvento responseEntity = await _personaEventoRepository.AddAsync(personaEvento, cancellationToken);

      PersonaEventoResponseDto responsePersonaDto = _mapper.Map<PersonaEventoResponseDto>(responseEntity);
      return Ok(Result<PersonaEventoResponseDto>.Success(responsePersonaDto));
    }
    catch (Exception ex)
    {
      return BadRequest(Result<PersonaEventoResponseDto>.Error(ex.Message));
    }
  }
}

