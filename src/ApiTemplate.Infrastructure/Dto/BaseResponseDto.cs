using System.Text.Json.Serialization;

namespace ApiTemplate.Infrastructure.Dto;
public abstract class BaseResponseDto
{
  [JsonPropertyOrder(-2)]
  public Guid Id { get; set; }
  public DateTimeOffset CreatedDate { get; set; }
}
