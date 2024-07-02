using ApiTemplate.Core.Entities.ValidationsAggregate;
using Ardalis.Specification;

namespace ApiTemplate.Core.Entities.ValidationAggregate.Specifications;
public class GetLastVerificationCodeSpec : Specification<VerificationCode>, ISingleResultSpecification
{
  public GetLastVerificationCodeSpec(string sentTo)
  {
    Query.Where(x => x.SentTo == sentTo).OrderByDescending(x => x.CreatedDate).Take(1);
  }
}
