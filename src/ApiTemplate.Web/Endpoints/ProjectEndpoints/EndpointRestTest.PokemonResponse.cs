using System.Runtime.Serialization;

namespace ApiTemplate.Web.Endpoints.ProjectEndpoints;

[DataContract]
public class PokemonResponse
{
  [DataMember(Name = "name")]
  public string? Name { get; set; }
}
