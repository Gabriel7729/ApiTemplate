using ApiTemplate.Core.Constants;
using ApiTemplate.Core.Entities.TravelAggregate;
using ApiTemplate.Core.Extensions;
using ApiTemplate.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTemplate.Core.Services;
public class TravelService : ITravelService
{
  private readonly IPdfService _pdfService;
  public TravelService(IPdfService pdfService)
  {
    _pdfService = pdfService;
  }

  public FileStreamResult GenerateTravelReceipt(Travel travel)
  {
    string template = FileManagment.ReadEmailTemplate(RouteConstans.PdfTemplateRoute, TemplateConstants.TravelReceiptTemplate);

    string htmlContent = template
                .Replace("{{TipoDocumento}}", travel.TipoDocumento)
                .Replace("{{Documento}}", travel.Documento)
                .Replace("{{Nombres}}", travel.Nombres)
                .Replace("{{Apellidos}}", travel.Apellidos)
                .Replace("{{Direccion}}", travel.Direccion)
                .Replace("{{Telefono}}", travel.Telefono)
                .Replace("{{FechadelViaje}}", travel.FechadelViaje.ToString("dd MMM yyyy"))
                .Replace("{{FechaRegistro}}", travel.FechaRegistro.ToString("dd MMM yyyy"))
                .Replace("{{Estado}}", travel.Estado)
                .Replace("{{MontoPagado}}", travel.MontoPagado.ToString("0.00"));

    FileStreamResult pdfFile = _pdfService.ConvertHtmlToPdf(htmlContent, $"TravelReceipt-{travel.Documento}.pdf");
    return pdfFile;
  }
}
