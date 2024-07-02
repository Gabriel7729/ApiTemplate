namespace ApiTemplate.Infrastructure.Dto.TravelDtos;
public class TravelDto
{
  public string TipoDocumento { get; set; } = string.Empty;
  public string Documento { get; set; } = string.Empty;
  public string Nombres { get; set; } = string.Empty;
  public string Apellidos { get; set; } = string.Empty;
  public string Direccion { get; set; } = string.Empty;
  public string Telefono { get; set; } = string.Empty;
  public DateTime FechadelViaje { get; set; }
  public DateTime FechaRegistro { get; set; }
  public string Estado { get; set; } = string.Empty;
  public decimal MontoPagado { get; set; }
}

public class TravelResponseDto : BaseResponseDto
{
  public string TipoDocumento { get; set; } = string.Empty;
  public string Documento { get; set; } = string.Empty;
  public string Nombres { get; set; } = string.Empty;
  public string Apellidos { get; set; } = string.Empty;
  public string Direccion { get; set; } = string.Empty;
  public string Telefono { get; set; } = string.Empty;
  public DateTime FechadelViaje { get; set; }
  public DateTime FechaRegistro { get; set; }
  public string Estado { get; set; } = string.Empty;
  public decimal MontoPagado { get; set; }
}
