namespace Sat.Recruitment.Domain;

/// <summary>
/// Validate entities by implementing the Specification pattern and the Notification pattern.
/// </summary>
/// <remarks>
/// <para>
/// Create a specification that is able to tell if a candidate object matches
/// some criteria. The specification has a method IsSatisfiedBy that returns
/// "true" if all criteria are met by an object.
/// </para>
/// <para>
/// Specifications:
/// <see href="https://martinfowler.com/apsupp/spec.pdf"/>
/// </para>
/// </remarks>
public interface ISpecification<T>
{
    public bool IsSatisfiedBy(T candidate, Notification notification);
}