using Scheduler.Domain.ValueObjects;

namespace Scheduler.Domain.Aggregates.Tasks;

public abstract class SingleTask : Task
{
    #region Public Methods
    public override void Execute()
    {
        ExecuteTask();
        this.Enabled = false;
    }
    
    public override string ToString()
        => $"Occurs once. Schedule will be used on {StartDate.Day} at " +
           $"{StartDate.TimeOfDay} starting on {StartDate}";

    public override DateTime CalculateNextExecutionTime()
        => StartDate;
    
    public override string Description()
        => ToString();
    #endregion

    #region Protected Methods
    protected SingleTask(DateTime dateTime)
    {
        NumberOfDays = (Days)Days.Create(0);
        Occurs = null;
        @DateTime = dateTime;
        this.StartDate = (DateTime)dateTime;
    }
    
    protected abstract void ExecuteTask();
    #endregion
}