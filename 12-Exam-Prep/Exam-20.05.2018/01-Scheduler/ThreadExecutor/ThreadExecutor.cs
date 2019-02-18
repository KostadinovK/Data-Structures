using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

/// <summary>
/// The ThreadExecutor is the concrete implementation of the IScheduler.
/// You can send any class to the judge system as long as it implements
/// the IScheduler interface. The Tests do not contain any <e>Reflection</e>!
/// </summary>
public class ThreadExecutor : IScheduler
{
    private int cycles;
    private Dictionary<int, Task> byId;
    private List<Task> byInsertion;
  
    public ThreadExecutor()
    {
        byId = new Dictionary<int, Task>();
        byInsertion = new List<Task>();
        cycles = 0;
    }

    public int Count => byId.Count;

    public void Execute(Task task)
    {
        if (byId.ContainsKey(task.Id))
        {
            throw new ArgumentException();
        }

        byId.Add(task.Id, task);
        byInsertion.Add(task);
    }

    public bool Contains(Task task)
    {
        return byId.ContainsKey(task.Id);
    }

    public Task GetById(int id)
    {
        if (!byId.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        return byId[id];
    }

    public Task GetByIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return byInsertion[index];
    }

    public int Cycle(int cycles)
    {
        if (Count == 0)
        {
            throw new InvalidOperationException();
        }

        List<Task> toRemove = new List<Task>();

        this.cycles += cycles;

        foreach (var task in byInsertion)
        {

            if (task.Consumption <= this.cycles)
            {
                toRemove.Add(task);
            }
        }

        toRemove.ForEach(x => byId.Remove(x.Id));
        toRemove.ForEach(x => byInsertion.Remove(x));
       
        return toRemove.Count;
    }

    public void ChangePriority(int id, Priority newPriority)
    {
        if (!byId.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        byId[id].TaskPriority = newPriority;

    }

    public IEnumerable<Task> GetByConsumptionRange(int lo, int hi, bool inclusive)
    {
        if (inclusive)
        {
            return byId.Values.Where(x => x.Consumption >= lo + cycles && x.Consumption <= hi + cycles).OrderBy(x => x);
        }

        return byId.Values.Where(x => x.Consumption > lo + cycles && x.Consumption < hi + cycles).OrderBy(x => x);
    }

    public IEnumerable<Task> GetByPriority(Priority type)
    {
        return byId.Values.Where(x => x.TaskPriority == type).OrderByDescending(x => x.Id);
    }

    public IEnumerable<Task> GetByPriorityAndMinimumConsumption(Priority priority, int lo)
    {
        return byId.Values.Where(x => x.TaskPriority == priority && x.Consumption >= lo).OrderByDescending(x => x.Id);
    }

    public IEnumerator<Task> GetEnumerator()
    {
        foreach (var task in byInsertion)
        {
            yield return task;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
