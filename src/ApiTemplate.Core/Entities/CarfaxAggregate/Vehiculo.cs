using ApiTemplate.SharedKernel;
using ApiTemplate.SharedKernel.Interfaces;

namespace ApiTemplate.Core.Entities.CarfaxAggregate;
public class Vehiculo : EntityBase, IAggregateRoot
{
  public string Matricula { get; set; } = string.Empty;
  public string Marca { get; set; } = string.Empty;
  public string Modelo { get; set; } = string.Empty;
  public string Anio { get; set; } = string.Empty;
  public string CantidadMillas { get; set; } = string.Empty;
  public string Motor { get; set; } = string.Empty;
  public string CantidadPasajeros { get; set; } = string.Empty;
  public ICollection<VehiculoEvento> Eventos { get; set; } = new List<VehiculoEvento>();
}
