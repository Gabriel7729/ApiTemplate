namespace ApiTemplate.Infrastructure.Dto.PersonaDtos;
public class PersonaEventoDto
{
  public string Tipo { get; set; } = string.Empty;
  public string Descripcion { get; set; } = string.Empty;
  public DateTime FechaInicio { get; set; }
  public int Duracion { get; set; }
  public string Estado { get; set; } = string.Empty;
  public Guid PersonaId { get; set; }
}

public class PersonaEventoResponseDto : BaseResponseDto
{
  public string Tipo { get; set; } = string.Empty;
  public string Descripcion { get; set; } = string.Empty;
  public DateTime FechaInicio { get; set; }
  public int Duracion { get; set; }
  public string Estado { get; set; } = string.Empty;
  public Guid PersonaId { get; set; }
}
