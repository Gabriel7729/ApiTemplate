namespace ApiTemplate.Infrastructure.Dto.PersonaDtos;
public class PersonaDto
{
  public string TipoDocumento { get; set; } = string.Empty;
  public string Documento { get; set; } = string.Empty;
  public string Nombres { get; set; } = string.Empty;
  public string Apellidos { get; set; } = string.Empty;
  public DateTime BirthDate { get; set; }
  public string Sexo { get; set; } = string.Empty;
  public int FelicidadAcumulada { get; set; }
  public ICollection<PersonaEventoDto> Eventos { get; set; } = new List<PersonaEventoDto>();
}

public class PersonaResponseDto : BaseResponseDto
{
  public string TipoDocumento { get; set; } = string.Empty;
  public string Documento { get; set; } = string.Empty;
  public string Nombres { get; set; } = string.Empty;
  public string Apellidos { get; set; } = string.Empty;
  public DateTime BirthDate { get; set; }
  public string Sexo { get; set; } = string.Empty;
  public int FelicidadAcumulada { get; set; }
  public ICollection<PersonaEventoDto> Eventos { get; set; } = new List<PersonaEventoDto>();
}
