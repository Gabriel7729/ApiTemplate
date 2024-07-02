using ApiTemplate.SharedKernel.Interfaces;
using ApiTemplate.SharedKernel;

namespace ApiTemplate.Core.Entities.PersonasAggregate;
public class Persona : EntityBase, IAggregateRoot
{
    public string Documento { get; set; } = string.Empty;
    public string Nombres { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string FechaNacimiento { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
}
