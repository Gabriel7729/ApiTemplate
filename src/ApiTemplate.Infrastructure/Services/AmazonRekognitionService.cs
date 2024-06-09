using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using ApiTemplate.Core.Interfaces;
using ApiTemplate.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ApiTemplate.Infrastructure.Services;
public class AmazonRekognitionService : IAmazonRekognitionService
{
  private readonly AmazonRekognitionClient _client;
  public AmazonRekognitionService(IConfiguration configuration)
  {
    _client = new AmazonRekognitionClient(configuration["ACCESS_AWS_KEY_ID"], configuration["ACCESS_SECRET_ACCESS_KEY"], RegionEndpoint.USEast1);
  }
  public async Task<CedulaDataResponse> GetCedulaDataFromImageAsync(IFormFile file)
  {
    using var memoryStream = new MemoryStream();
    await file.CopyToAsync(memoryStream);
    memoryStream.Seek(0, SeekOrigin.Begin);

    var image = new Image
    {
      Bytes = memoryStream
    };
    DetectTextRequest request = new DetectTextRequest()
    {
      Image = image
    };
    DetectTextResponse response = await _client.DetectTextAsync(request);

    CedulaDataResponse cedulaDataResponse = new();

    foreach (var item in response.TextDetections)
    {
      if (item.DetectedText.Length == 13 &&
          item.DetectedText[3] == '-' && item.DetectedText[11] == '-')
      {
        string cedulaWithoutFormatting = item.DetectedText;
        char guion = '-';
        cedulaDataResponse.Documento = RemoveCharacter(cedulaWithoutFormatting, guion);
      }

      if (item.Id == 7)
      {
        cedulaDataResponse.FechaNacimiento = item.DetectedText;
      }

      if (item.Id == 13)
      {
        cedulaDataResponse.Estado = item.DetectedText;
      }

      if (item.Id == 20)
      {
        cedulaDataResponse.Nombres = item.DetectedText;
      }

      if (item.Id == 24)
      {
        cedulaDataResponse.Apellidos = item.DetectedText;
      }
    }

    return cedulaDataResponse;
  }

  private static string RemoveCharacter(string input, char character)
  {
    return input.Replace(character.ToString(), string.Empty);
  }
}
