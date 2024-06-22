using System.Globalization;
using ApiTemplate.Core.Abstracts;
using ApiTemplate.Core.Constants;
using ApiTemplate.Core.Extensions;
using ApiTemplate.Core.Interfaces;
using Ardalis.ApiEndpoints;
using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiTemplate.Web.Endpoints.UserValidationEndpoints;

public class SendEmailWithAttachment : EndpointBaseAsync
      .WithRequest<SendEmailWithAttachmentRequest>
      .WithActionResult<GeneralResponse>
{

  private readonly IEmailSender _emailSender;
  public SendEmailWithAttachment(
    IEmailSender emailSender)
  {
    _emailSender = emailSender;
  }

  [HttpPost("/api/Send/Email")]
  [SwaggerOperation(
      Summary = "Send Email",
      Description = "Send Email",
      OperationId = "Send.Email",
      Tags = new[] { "EmailEndpoints" })
  ]
  public override async Task<ActionResult<GeneralResponse>> HandleAsync([FromBody] SendEmailWithAttachmentRequest request,
      CancellationToken cancellationToken)
  {
    try
    {
      if (string.IsNullOrWhiteSpace(request.Email))
        throw new Exception("The PhoneNumber or Email is required");

      var template = FileManagment.ReadEmailTemplate(RouteConstans.EmailTemplateRoute, TemplateConstants.AttachmentTemplate);

      string route = Path.Combine(RouteConstans.PdfTemplateRoute, TemplateConstants.CarfaxReportTemplate);

      await _emailSender.SendEmailAsync(new List<string>() { request.Email }, "Correo con Archivo", template, new List<string>() { route });

      var response = new GeneralResponse(true, "Email Sended Successfully");

      return Ok(Result<GeneralResponse>.Success(response));
    }
    catch (Exception exception)
    {
      return BadRequest(Result<GeneralResponse>.Error(exception.Message));
    }
  }
}
