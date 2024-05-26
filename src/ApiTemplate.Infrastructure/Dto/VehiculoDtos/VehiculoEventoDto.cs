namespace ApiTemplate.Infrastructure.Dto.VehiculoDtos;
public class VehiculoEventoDto
{
  public string Tipo { get; set; } = string.Empty;
  public string Descripcion { get; set; } = string.Empty;
  public string Estado { get; set; } = string.Empty;
  public Guid VehiculoId { get; set; }
}

public class VehiculoEventoResponseDto : BaseResponseDto
{
  public string Tipo { get; set; } = string.Empty;
  public string Descripcion { get; set; } = string.Empty;
  public string Estado { get; set; } = string.Empty;
  public Guid VehiculoId { get; set; }
}
