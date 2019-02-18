using System;
using System.Collections.Generic;


/// <summary>
/// This is the Scheduler interface that will be used for testing in the judge
/// system. Please do not modify it, because you might face issues when submitting
/// your code to the system.
/// </summary>
public interface IScheduler : IEnumerable<Task>
{
    int Count { get; }

    void Execute(Task task);
    bool Contains(Task task);

    Task GetById(int id);
    Task GetByIndex(int index);

    int Cycle(int cycles);
    void ChangePriority(int id, Priority newPriority);
  
    IEnumerable<Task> GetByConsumptionRange(int lo, int hi, bool inclusive);
    IEnumerable<Task> GetByPriority(Priority type);
    IEnumerable<Task> GetByPriorityAndMinimumConsumption(Priority priority, int lo);
}

