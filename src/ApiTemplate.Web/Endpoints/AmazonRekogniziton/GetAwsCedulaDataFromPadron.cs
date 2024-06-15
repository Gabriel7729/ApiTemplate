using ApiTemplate.Core.Interfaces;
using ApiTemplate.Core.Models;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.AmazonRekogniziton;

public class GetAwsCedulaDataFromPadron : EndpointBaseAsync
      .WithRequest<IFormFile>
      .WithActionResult<Padron>
{
  private readonly IAmazonRekognitionService _amazonRekognitionService;

  public GetAwsCedulaDataFromPadron(
    IAmazonRekognitionService amazonRekognitionService)
  {
    _amazonRekognitionService = amazonRekognitionService;
  }

  [HttpPost("/Amazon/Rekognition/Cedula/Padron/Data")]
  [SwaggerOperation(
      Summary = "Get cedula data from Amazon Rekognition and Padron",
      Description = "Get cedula data from Amazon Rekognition and Padron",
      OperationId = "AmazonRekognitionPadron.GetCedulaData",
      Tags = new[] { "AmazonRekognitionEndpoints" })
  ]
  public override async Task<ActionResult<Padron>> HandleAsync(IFormFile file,
      CancellationToken cancellationToken)
  {
    try
    {
      Padron padronCedula = await _amazonRekognitionService.GetCedulaDataFromPadronAsync(file);
      return Ok(padronCedula);
    }
    catch (Exception ex)
    {
      return BadRequest(Result<Padron>.Error(ex.Message));
    }
  }
}


