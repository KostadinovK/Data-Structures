
using System;
/// <summary>
/// The Task class is the entity that will be used across the application.
/// Please, do not modify its' constructor, otherwise you might encounter issues
/// when running your code on the system
/// </summary>
public class Task : IComparable<Task>
{

    public int Id { get; private set; }
    public int Consumption { get; set; }
    public Priority TaskPriority { get; set; }

    public Task(int id, int consumption, Priority priority)
    {

        this.Id = id;
        this.Consumption = consumption;
        this.TaskPriority = priority;

    }

    public int CompareTo(Task other)
    {
        int compare = this.Consumption.CompareTo(other.Consumption);
        if (compare == 0)
        {
            return other.TaskPriority.CompareTo(this.TaskPriority);
        }
        return compare;
    }
}