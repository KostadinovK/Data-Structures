using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

[TestFixture]
public class Perf4
{
    [TestCase]
    [Timeout(12000)]
    public void GetByConsumptionRange_ThreadExecutor_ShouldWorkFast()
    {
        //Arange
        const int items = 100_000;

        IScheduler executor = new ThreadExecutor();
        Stopwatch watch = new Stopwatch();
        List<Task> expected = new List<Task>();
        Priority[] priorities = new Priority[] { Priority.LOW, Priority.MEDIUM, Priority.HIGH, Priority.EXTREME };
        Random rand = new Random();

        //Act
        for (int i = 0; i < items; i++)
        {
            Task task = new Task(i, rand.Next(0, 10000), priorities[rand.Next(0,4)]);
            expected.Add(task);
            executor.Execute(task);
        }

        //do
        List<Tuple<int,int>> ranges = new List<Tuple<int,int>>();
        List<List<Task>> tasks = new List<List<Task>>();
        for(int i = 0; i < 100; i++)
        {
            int lower = rand.Next(2500, 5000);
            int upper = rand.Next(5005, 9999);

            ranges.Add(new Tuple<int, int>(lower, upper));
            tasks.Add(expected
                        .Where(x => x.Consumption >= lower && x.Consumption <= upper)
                        .OrderBy(x => x.Consumption)
                        .ThenByDescending(x => x.TaskPriority)
                        .ToList()
                     );
        }

        watch.Start();

        List<IEnumerable<Task>> actualTasks = new List<IEnumerable<Task>>();

        for(int i = 0; i < 100; i++)
        {
            var range = ranges[i];
            actualTasks.Add(executor.GetByConsumptionRange(range.Item1, range.Item2, true));
        }

        watch.Stop();

        //Assert
        Assert.Less(watch.ElapsedMilliseconds, 200);
        CollectionAssert.AreEqual(tasks, actualTasks);
    }

}
