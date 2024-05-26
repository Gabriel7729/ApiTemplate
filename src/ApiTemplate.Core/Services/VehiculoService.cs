using System.Text;
using ApiTemplate.Core.Constants;
using ApiTemplate.Core.Entities.CarfaxAggregate;
using ApiTemplate.Core.Extensions;
using ApiTemplate.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTemplate.Core.Services;
public class VehiculoService : IVehiculoService
{
  private readonly IPdfService _pdfService;
  public VehiculoService(IPdfService pdfService)
  {
    _pdfService = pdfService;
  }

  public FileStreamResult GenerateCarfaxReport(Vehiculo vehiculo)
  {
    string template = FileManagment.ReadEmailTemplate(RouteConstans.PdfTemplateRoute, TemplateConstants.CarfaxReportTemplate);

    StringBuilder eventosHtml = new StringBuilder();
    foreach (var evento in vehiculo.Eventos)
    {
      eventosHtml.AppendLine($@"
                <tr>
                    <td>{evento.Tipo}</td>
                    <td>{evento.Descripcion}</td>
                    <td>{evento.Estado}</td>
                </tr>");
    }

    string htmlContent = template
        .Replace("{{ Matricula }}", vehiculo.Matricula)
        .Replace("{{ Marca }}", vehiculo.Marca)
        .Replace("{{ Modelo }}", vehiculo.Modelo)
        .Replace("{{ Anio }}", vehiculo.Anio)
        .Replace("{{ CantidadMillas }}", vehiculo.CantidadMillas)
        .Replace("{{ Motor }}", vehiculo.Motor)
        .Replace("{{ CantidadPasajeros }}", vehiculo.CantidadPasajeros)
        .Replace("{{ Eventos }}", eventosHtml.ToString());

    FileStreamResult pdfFile = _pdfService.ConvertHtmlToPdf(htmlContent, $"CarfaxReport-{vehiculo.Marca}-{vehiculo.Modelo}-{vehiculo.Matricula}");
    return pdfFile;
  }
}
