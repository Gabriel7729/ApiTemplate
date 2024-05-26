namespace ApiTemplate.Web.Endpoints.PersonaEndpoints;

public class ListPaginatedRequest
{
  public int PageNumber { get; set; } = 10;
  public int PageSize { get; set; } = 1;
}
