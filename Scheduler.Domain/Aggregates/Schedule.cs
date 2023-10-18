namespace Scheduler.Domain.Aggregates;
using Scheduler.Domain.Aggregates.Tasks;

public class Schedule
{
    #region Properties
    public Guid ScheduleID { get; }
    public DateTime Date { get; private set; }
    public List<Task> Tasks { get; }
    #endregion

    #region Ctors
    public Schedule(DateTime date, List<Task> tasks)
    {
        Date = date;
        Tasks = tasks;
    }
    #endregion
    
    #region Public Methods
    public void AddTask(Task task)
        => Tasks.Add(task);
    
    public void RemoveTask(Task task)
        => Tasks.Remove(task);
    
    public void Run()
    {
        foreach (var task in Tasks)
            task.Execute();
        RemoveFinishedTasks();
    }
    #endregion

    #region Private Methods
    private void RemoveFinishedTasks()
    {
        foreach (var task in Tasks.Where(task => task.Enabled))
            this.RemoveTask(task);
    }
    #endregion
}