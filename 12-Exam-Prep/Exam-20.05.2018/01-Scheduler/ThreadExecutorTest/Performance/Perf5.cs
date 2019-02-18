
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

[TestFixture]
public class Perf5
{

    [TestCase]
    public void Cycle_ThreadExecutor_ShouldRemoveFast()
    {
        //Arange
        const int count = 100_000;

        IScheduler executor = new ThreadExecutor();
        Stopwatch watch = new Stopwatch();
        
        Random rand = new Random();
        Priority[] priorities = new Priority[] { Priority.LOW, Priority.MEDIUM, Priority.HIGH, Priority.EXTREME };

        List<Task> tasks = new List<Task>();

        //Act
        for (int i = 1; i < count; i++)
        {
            Task t = new Task(i, i, priorities[rand.Next(0,4)]);
            tasks.Add(t);
            executor.Execute(t);
        }
        
        watch.Start();

        int totalCycles = 0;
        for(int i = 0; i < 1000; i++)
        {
            int cycles = rand.Next(10, 100);
            executor.Cycle(cycles);
            totalCycles += cycles;
        }
        List<Task> exepcted = tasks.Skip(totalCycles).ToList();
        CollectionAssert.AreEqual(exepcted, executor.ToList());

        watch.Stop();

        //Assert
        Assert.Less(watch.ElapsedMilliseconds, 200);
    }

}
