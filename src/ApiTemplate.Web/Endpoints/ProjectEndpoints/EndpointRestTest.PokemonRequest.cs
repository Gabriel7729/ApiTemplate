using System.ComponentModel.DataAnnotations;

namespace ApiTemplate.Web.Endpoints.ProjectEndpoints;

public class PokemonRequest
{
  [Required]
  public int PokemonId { get; set; }
}
