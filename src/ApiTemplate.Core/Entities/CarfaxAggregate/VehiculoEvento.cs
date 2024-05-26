using ApiTemplate.SharedKernel;
using ApiTemplate.SharedKernel.Interfaces;

namespace ApiTemplate.Core.Entities.CarfaxAggregate;
public class VehiculoEvento : EntityBase, IAggregateRoot
{
    public string Tipo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public Guid VehiculoId { get; set; }
}
