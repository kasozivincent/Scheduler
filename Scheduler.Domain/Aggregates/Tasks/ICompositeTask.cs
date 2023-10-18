namespace Scheduler.Domain.Aggregates.Tasks;

public abstract class CompositeTask : Task
{
    private readonly IEnumerable<Task> _tasks;

    protected CompositeTask(IEnumerable<Task> tasks) : base() => this._tasks = tasks;

    public override DateTime CalculateNextExecutionTime()
    {
        throw new NotImplementedException();
    }
}