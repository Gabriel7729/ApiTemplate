using ApiTemplate.Core.Models;
using Microsoft.AspNetCore.Http;

namespace ApiTemplate.Core.Interfaces;
public interface IAmazonRekognitionService
{
  Task<CedulaDataResponse> GetCedulaDataFromImageAsync(IFormFile file);
  Task<BuscadosResponse> FindBuscadoPeopleAsync(IFormFile file);
}
