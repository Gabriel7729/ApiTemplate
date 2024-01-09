using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ApiTemplate.Web.Endpoints.ProjectEndpoints;

public class CompleteItemRequest
{
  public const string Route = "/Projects/Items/{projectid}/{itemid}";
  [FromRoute(Name = "projectid")] public Guid ProjectId { get; set; }
  [FromRoute(Name = "itemid")] public Guid ItemId { get; set; }
}
