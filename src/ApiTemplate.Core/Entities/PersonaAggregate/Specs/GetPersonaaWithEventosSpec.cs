using Ardalis.Specification;

namespace ApiTemplate.Core.Entities.PersonaAggregate.Specs;
public class GetPersonaaWithEventosSpec : Specification<Persona>, ISingleResultSpecification
{
  public GetPersonaaWithEventosSpec(Guid personaId)
  {
        Query
            .Where(x => x.Id == personaId)
            .Include(x => x.Eventos);
    }
}
