using Scheduler.Domain.ValueObjects;

namespace Scheduler.Domain.Aggregates.Tasks;

public abstract class RecurringTask : Task
{
    protected RecurringTask(Frequency frequency, Days days)
    {
        this.Occurs = frequency;
        this.DateTime = null;
        this.NumberOfDays = days;
    }

    public override string ToString()
        => $"Occurs {nameof(Occurs)}. Schedule will be used starting {StartDate}";

    public override void Execute()
    {
        
        // Check if it is done and set its Enabled to false
    }

    public override DateTime CalculateNextExecutionTime()
        => this.Occurs! switch
            {
                Frequency.Daily => StartDate.AddDays(1),
                Frequency.Weekly => StartDate.AddDays(7),
                Frequency.Monthly => StartDate.AddDays(30),
                _ => throw new ArgumentOutOfRangeException()
            };
    
    public override string Description()
        => ToString();
}