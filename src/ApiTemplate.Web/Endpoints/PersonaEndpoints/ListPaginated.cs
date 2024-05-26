using ApiTemplate.Core.Abstracts;
using ApiTemplate.Core.Entities.AbstractsEntities;
using ApiTemplate.Core.Entities.PersonaAggregate;
using ApiTemplate.Infrastructure.Dto.PersonaDtos;
using ApiTemplate.SharedKernel.Interfaces;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.PersonaEndpoints;

public class ListPaginated : EndpointBaseAsync
      .WithRequest<ListPaginatedRequest>
      .WithActionResult<PaginationResult<List<PersonaResponseDto>>>
{
  private readonly IRepository<Persona> _repository;
  private readonly IMapper _mapper;

  public ListPaginated(IRepository<Persona> repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }

  [HttpGet("/Persona/Paginated")]
  [SwaggerOperation(
      Summary = "List all Personas",
      Description = "List all Personas",
      OperationId = "Persona.ListPaginated",
      Tags = new[] { "PersonaEndpoints" })
  ]
  public override async Task<ActionResult<PaginationResult<List<PersonaResponseDto>>>> HandleAsync([FromQuery] ListPaginatedRequest request,
      CancellationToken cancellationToken)
  {
    try
    {
      EntityPaginateSpec<Persona> spec = new(request.PageNumber, request.PageSize);
      List<Persona> personas = await _repository.ListAsync(spec, cancellationToken);
      List<PersonaResponseDto> vehiculosResponseDto = _mapper.Map<List<PersonaResponseDto>>(personas);

      var paginatedInstance = new Paginate<Persona, List<PersonaResponseDto>>(_repository);
      var paginatedList = await paginatedInstance.GetResponse(
          request.PageNumber,
          request.PageSize,
          vehiculosResponseDto);

      var result = Result<PaginationResult<List<PersonaResponseDto>>>.Success(paginatedList);

      return Ok(result);
    }
    catch (Exception ex)
    {
      return BadRequest(Result<PaginationResult<List<PersonaResponseDto>>>.Error(ex.Message));
    }
  }
}

