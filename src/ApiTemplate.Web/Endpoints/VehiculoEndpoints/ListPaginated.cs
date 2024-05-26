using ApiTemplate.Core.Abstracts;
using ApiTemplate.Core.Entities.AbstractsEntities;
using ApiTemplate.Core.Entities.CarfaxAggregate;
using ApiTemplate.Infrastructure.Dto.VehiculoDtos;
using ApiTemplate.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.VehiculoEndpoints;

public class ListPaginated : EndpointBaseAsync
      .WithRequest<ListPaginatedRequest>
      .WithActionResult<PaginationResult<List<VehiculoResponseDto>>>
{
  private readonly IRepository<Vehiculo> _repository;
  private readonly IMapper _mapper;

  public ListPaginated(IRepository<Vehiculo> repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  [HttpGet("/Vehiculos/Paginated")]
  [SwaggerOperation(
      Summary = "List all Vehiculos",
      Description = "List all Vehiculos",
      OperationId = "Vehiculo.ListPaginated",
      Tags = new[] { "VehiculoEndpoints" })
  ]
  public override async Task<ActionResult<PaginationResult<List<VehiculoResponseDto>>>> HandleAsync([FromQuery] ListPaginatedRequest request,
      CancellationToken cancellationToken)
  {
    try
    {
      EntityPaginateSpec<Vehiculo> spec = new(request.PageNumber, request.PageSize);
      List<Vehiculo> vehiculos = await _repository.ListAsync(spec, cancellationToken);
      List<VehiculoResponseDto> vehiculosResponseDto = _mapper.Map<List<VehiculoResponseDto>>(vehiculos);

      var paginatedInstance = new Paginate<Vehiculo, List<VehiculoResponseDto>>(_repository);
      var paginatedList = await paginatedInstance.GetResponse(
          request.PageNumber,
          request.PageSize,
          vehiculosResponseDto);

      var result = Result<PaginationResult<List<VehiculoResponseDto>>>.Success(paginatedList);

      return Ok(result);
    }
    catch (Exception ex)
    {
      return BadRequest(Result<PaginationResult<List<VehiculoResponseDto>>>.Error(ex.Message));
    }
  }
}

