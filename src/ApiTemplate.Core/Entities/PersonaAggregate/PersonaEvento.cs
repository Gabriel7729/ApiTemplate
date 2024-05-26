using ApiTemplate.SharedKernel;
using ApiTemplate.SharedKernel.Interfaces;

namespace ApiTemplate.Core.Entities.PersonaAggregate;
public class PersonaEvento : EntityBase, IAggregateRoot
{
    public string Tipo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public int Duracion { get; set; }
    public string Estado { get; set; } = string.Empty;
    public Guid PersonaId { get; set; }
}
