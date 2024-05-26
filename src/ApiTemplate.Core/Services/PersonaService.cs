using System.Text;
using ApiTemplate.Core.Constants;
using ApiTemplate.Core.Entities.PersonaAggregate;
using ApiTemplate.Core.Extensions;
using ApiTemplate.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTemplate.Core.Services;
public class PersonaService : IPersonaService
{
  private readonly IPdfService _pdfService;
  public PersonaService(IPdfService pdfService)
  {
    _pdfService = pdfService;
  }

  public FileStreamResult GenerateFelicidadPersonaReport(Persona persona)
  {
    string template = FileManagment.ReadEmailTemplate(RouteConstans.PdfTemplateRoute, TemplateConstants.FelicidadPersonaReportTemplate);

    StringBuilder eventosHtml = new StringBuilder();
    foreach (var evento in persona.Eventos)
    {
      eventosHtml.AppendLine($@"
                <tr>
                    <td>{evento.Tipo}</td>
                    <td>{evento.Descripcion}</td>
                    <td>{evento.FechaInicio:yyyy-MM-dd}</td>
                    <td>{evento.Duracion}</td>
                    <td>{evento.Estado}</td>
                </tr>");
    }

    string htmlContent = template
        .Replace("{{ TipoDocumento }}", persona.TipoDocumento)
        .Replace("{{ Documento }}", persona.Documento)
        .Replace("{{ Nombres }}", persona.Nombres)
        .Replace("{{ Apellidos }}", persona.Apellidos)
        .Replace("{{ BirthDate }}", persona.BirthDate.ToString("yyyy-MM-dd"))
        .Replace("{{ Sexo }}", persona.Sexo)
        .Replace("{{ FelicidadAcumulada }}", persona.FelicidadAcumulada.ToString())
        .Replace("{{ Eventos }}", eventosHtml.ToString());

    FileStreamResult pdfFile = _pdfService.ConvertHtmlToPdf(htmlContent, $"CarfaxReport-{persona.Nombres}-{persona.Apellidos}");
    return pdfFile;
  }
}
