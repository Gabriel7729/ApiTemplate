using ApiTemplate.Core.Entities.TravelAggregate;
using ApiTemplate.Core.Interfaces;
using ApiTemplate.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.TravelEndpoints;

public class ReceiptTravel : EndpointBaseAsync
      .WithRequest<Guid>
      .WithoutResult
{
  private readonly IRepository<Travel> _repository;
  private readonly ITravelService _travelService;

  public ReceiptTravel(IRepository<Travel> repository, ITravelService travelService)
  {
    _repository = repository;
    _travelService = travelService;
  }

  [HttpPost("/Travel/{travelId:guid}/Receipt")]
  [SwaggerOperation(
      Summary = "Get Receipt Report",
      Description = "Get Receipt Report",
      OperationId = "Travel.Receipt.Report",
      Tags = new[] { "TravelEndpoints" })
  ]
  public override async Task<ActionResult> HandleAsync([FromRoute] Guid travelId,
      CancellationToken cancellationToken)
  {
    try
    {
      Travel? travel = await _repository.GetByIdAsync(travelId, cancellationToken);
      if (travel is null)
        return NotFound(Result<FileStreamResult>.Error("Travel not found"));

      var file = _travelService.GenerateTravelReceipt(travel);
      return File(file.FileStream, file.ContentType);
    }
    catch (Exception ex)
    {
      return BadRequest(Result<FileStreamResult>.Error(ex.Message));
    }
  }
}

