using ApiTemplate.Core.Entities.PersonasAggregate;
using ApiTemplate.Core.Interfaces;
using ApiTemplate.Core.Models;
using ApiTemplate.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.AmazonRekogniziton;

public class GetCedulaDataFromImage : EndpointBaseAsync
      .WithRequest<IFormFile>
      .WithActionResult<CedulaDataResponse>
{
  private readonly IAmazonRekognitionService _amazonRekognitionService;
  private readonly IRepository<Persona> _personaRepository;

  public GetCedulaDataFromImage(
    IAmazonRekognitionService amazonRekognitionService,
    IRepository<Persona> personaRepository)
  {
    _amazonRekognitionService = amazonRekognitionService;
    _personaRepository = personaRepository;
  }

  [HttpPost("/Amazon/Rekognition/Cedula/Data")]
  [SwaggerOperation(
      Summary = "Get cedula data from Amazon Rekognition",
      Description = "Get cedula data from Amazon Rekognition",
      OperationId = "AmazonRekognition.GetCedulaData",
      Tags = new[] { "AmazonRekognitionEndpoints" })
  ]
  public override async Task<ActionResult<CedulaDataResponse>> HandleAsync(IFormFile file,
      CancellationToken cancellationToken)
  {
    try
    {
      CedulaDataResponse cedulaDataResponse = await _amazonRekognitionService.GetCedulaDataFromImageAsync(file);

      Persona persona = new()
      {
        Documento = cedulaDataResponse.Documento,
        Nombres = cedulaDataResponse.Nombres,
        Apellidos = cedulaDataResponse.Apellidos,
        FechaNacimiento = cedulaDataResponse.FechaNacimiento,
        Estado = cedulaDataResponse.Estado
      };

      await _personaRepository.AddAsync(persona, cancellationToken);

      return Ok(cedulaDataResponse);
    }
    catch (Exception ex)
    {
      return BadRequest(Result<CedulaDataResponse>.Error(ex.Message));
    }
  }
}


