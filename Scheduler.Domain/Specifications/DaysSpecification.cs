namespace Scheduler.Domain.Specifications;

public class DaysSpecification : BaseSpecification<int>
{
    public override bool Satisfies(int value)
       => value is > 0 and < 20;
}