using ApiTemplate.SharedKernel;
using ApiTemplate.SharedKernel.Interfaces;

namespace ApiTemplate.Core.Entities.TravelAggregate;
public class Travel : EntityBase, IAggregateRoot
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
