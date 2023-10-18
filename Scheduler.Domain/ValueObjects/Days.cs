using LanguageExt;
using static LanguageExt.Prelude;
using Scheduler.Domain.Specifications;

namespace Scheduler.Domain.ValueObjects;

public record Days
{
    public int Value { get; }
    private static readonly DaysSpecification Spec = new DaysSpecification();

    private Days(int days)
        => Value = days;
    public static Option<Days> Create(int days)
        => Spec.Satisfies(days) 
            ? new Days(days) 
            : None;
}