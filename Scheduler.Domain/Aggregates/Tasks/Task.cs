using Scheduler.Domain.ValueObjects;
namespace Scheduler.Domain.Aggregates.Tasks;

public abstract class Task
{
    #region Private Fields
    private DateTime _startDate;
    private DateTime _endDate;
    #endregion
    
    #region Properties
    public Guid TaskId { get; private set; }
    public Frequency? Occurs { get; protected set; }
    public DateTime? @DateTime { get; protected set; }
    
    public DateTime EndDate
    {
        get => _endDate;
        set
        {
            if (value < StartDate)
                throw new ArgumentException("End date must be greater than or equal to start date.");
            _endDate = value;
        }
    }
    public Days NumberOfDays { get; protected set; }
    public bool Enabled { get; protected set; } = true;
    public DateTime StartDate
    {
        get => _startDate;
        set
        {
            if (value > EndDate)
                throw new ArgumentException("Start date must be less than or equal to end date.");
            _startDate = value;
        }
    }
    #endregion

    #region Abstract Methods
    public abstract DateTime CalculateNextExecutionTime();
    public abstract string Description();
    public abstract void Execute();
    #endregion

}