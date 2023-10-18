namespace Scheduler.Domain.Specifications;

public abstract class BaseSpecification<T>
{
    public abstract bool Satisfies(T value);
}