using ApiTemplate.Core.Entities.PersonaAggregate;
using Microsoft.AspNetCore.Mvc;

namespace ApiTemplate.Core.Interfaces;
public interface IPersonaService
{
  FileStreamResult GenerateFelicidadPersonaReport(Persona persona);
}
