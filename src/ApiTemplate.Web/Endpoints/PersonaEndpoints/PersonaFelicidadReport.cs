using ApiTemplate.Core.Entities.PersonaAggregate;
using ApiTemplate.Core.Entities.PersonaAggregate.Specs;
using ApiTemplate.Core.Interfaces;
using ApiTemplate.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.PersonaEndpoints;

public class PersonaFelicidadReport : EndpointBaseAsync
      .WithRequest<Guid>
      .WithoutResult
{
  private readonly IRepository<Persona> _repository;
  private readonly IPersonaService _personaService;

  public PersonaFelicidadReport(IRepository<Persona> repository, IPersonaService personaService)
  {
    _repository = repository;
    _personaService = personaService;
  }

  [HttpPost("/Persona/{personaId:guid}/Felicidad/Report")]
  [SwaggerOperation(
      Summary = "Get Felicidad Report",
      Description = "Get Felicidad Report",
      OperationId = "Persona.Felicidad.Report",
      Tags = new[] { "PersonaEndpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] Guid personaId,
      CancellationToken cancellationToken)
  {
    try
    {
      GetPersonaaWithEventosSpec spec = new(personaId);
      Persona? persona = await _repository.GetBySpecAsync(spec, cancellationToken);
      if (persona is null)
        return NotFound(Result<FileStreamResult>.Error("Persona not found"));

      var file = _personaService.GenerateFelicidadPersonaReport(persona);
      return File(file.FileStream, file.ContentType);
    }
    catch (Exception ex)
    {
      return BadRequest(Result<FileStreamResult>.Error(ex.Message));
    }
  }
}
