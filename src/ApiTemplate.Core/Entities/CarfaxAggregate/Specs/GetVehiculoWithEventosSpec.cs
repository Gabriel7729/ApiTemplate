using Ardalis.Specification;

namespace ApiTemplate.Core.Entities.CarfaxAggregate.Specs;
public class GetVehiculoWithEventosSpec : Specification<Vehiculo>, ISingleResultSpecification
{
  public GetVehiculoWithEventosSpec(Guid vehiculoId)
  {
    Query
        .Where(x => x.Id == vehiculoId)
        .Include(x => x.Eventos);
  }
}
