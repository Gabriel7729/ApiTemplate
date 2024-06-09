using ApiTemplate.Core.Interfaces;
using ApiTemplate.Core.Models;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.AmazonRekogniziton;

public class FindBuscadoFromImage : EndpointBaseAsync
      .WithRequest<IFormFile>
      .WithActionResult<BuscadosResponse>
{
  private readonly IAmazonRekognitionService _amazonRekognitionService;

  public FindBuscadoFromImage(
    IAmazonRekognitionService amazonRekognitionService)
  {
    _amazonRekognitionService = amazonRekognitionService;
  }

  [HttpPost("/Amazon/Rekognition/Buscado")]
  [SwaggerOperation(
      Summary = "Get Buscado data from Amazon Rekognition",
      Description = "Get Buscado data from Amazon Rekognition",
      OperationId = "AmazonRekognition.GetBuscdoData",
      Tags = new[] { "AmazonRekognitionEndpoints" })
  ]
  public override async Task<ActionResult<BuscadosResponse>> HandleAsync(IFormFile file,
      CancellationToken cancellationToken)
  {
    try
    {
      BuscadosResponse response = await _amazonRekognitionService.FindBuscadoPeopleAsync(file);
      return Ok(response);
    }
    catch (Exception ex)
    {
      return BadRequest(Result<BuscadosResponse>.Error(ex.Message));
    }
  }
}


