using Amazon;
using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using ApiTemplate.Core.Interfaces;
using ApiTemplate.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ApiTemplate.Infrastructure.Services;
public class AmazonRekognitionService : IAmazonRekognitionService
{
  private readonly AmazonRekognitionClient _client;
  public AmazonRekognitionService(IConfiguration configuration)
  {
    string accessKeyId = configuration["ACCESS_AWS_KEY_ID"];
    string secretAccessKey = configuration["ACCESS_SECRET_ACCESS_KEY"];
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
  public async Task<Padron> GetCedulaDataFromPadronAsync(IFormFile file)
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
    }

    Padron padron = await FindCedulaIdAsync(cedulaDataResponse.Documento);

    return padron;
  }

  private async Task<Padron> FindCedulaIdAsync(string _cedula)
  {

    using HttpClient httpClient = new HttpClient();
    try
    {
      string cedula = _cedula;

      string json = httpClient.GetStringAsync($"https://compulaboratoriomendez.com/lib/?Key=DESARROLLOWEB&MUN_CED={_cedula.Substring(0, 3)}&SEQ_CED={_cedula.Substring(3, 7)}&VER_CED={_cedula.Substring(10, 1)}").Result;

      var padron = JsonConvert.DeserializeObject<Padron[]>(json)[0];

      return padron;

    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
  private static string RemoveCharacter(string input, char character)
  {
    return input.Replace(character.ToString(), string.Empty);
  }
}
