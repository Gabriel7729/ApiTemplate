namespace ApiTemplate.Infrastructure.Dto.VehiculoDtos;
public class VehiculoDto
{
  public string Matricula { get; set; } = string.Empty;
  public string Marca { get; set; } = string.Empty;
  public string Modelo { get; set; } = string.Empty;
  public string Anio { get; set; } = string.Empty;
  public string CantidadMillas { get; set; } = string.Empty;
  public string Motor { get; set; } = string.Empty;
  public string CantidadPasajeros { get; set; } = string.Empty;
}

public class VehiculoResponseDto : BaseResponseDto
{
  public string Matricula { get; set; } = string.Empty;
  public string Marca { get; set; } = string.Empty;
  public string Modelo { get; set; } = string.Empty;
  public string Anio { get; set; } = string.Empty;
  public string CantidadMillas { get; set; } = string.Empty;
  public string Motor { get; set; } = string.Empty;
  public string CantidadPasajeros { get; set; } = string.Empty;
  public ICollection<VehiculoEventoResponseDto> Eventos { get; set; } = new List<VehiculoEventoResponseDto>();
}
