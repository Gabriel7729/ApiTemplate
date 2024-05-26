using ApiTemplate.SharedKernel;
using ApiTemplate.SharedKernel.Interfaces;

namespace ApiTemplate.Core.Entities.PersonaAggregate;
public class Persona : EntityBase, IAggregateRoot
{
  public string TipoDocumento { get; set; } = string.Empty;
  public string Documento { get; set; } = string.Empty;
  public string Nombres { get; set; } = string.Empty;
  public string Apellidos { get; set; } = string.Empty;
  public DateTime BirthDate { get; set; }
  public string Sexo { get; set; } = string.Empty;
  public int FelicidadAcumulada { get; set; }
  public ICollection<PersonaEvento> Eventos { get; set; } = new List<PersonaEvento>();
}
