namespace ApiTemplate.Web.Endpoints.VehiculoEndpoints;

public class ListPaginatedRequest
{
  public int PageNumber { get; set; } = 10;
  public int PageSize { get; set; } = 1;
}
