using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestFixture]
public class Perf3
{
    [TestCase]
    public void FindByIndex_ThreadExecutor_ShouldWorkFast()
    {
        // Arrange
        IScheduler executor = new ThreadExecutor();
        const int count = 10000;
        List<Task> tasks = new List<Task>();
        
        for (int i = 0; i < count; i++)
        {
            tasks.Add(new Task(i, i, Priority.HIGH));
            executor.Execute(tasks[i]);
        }

        // Act
        Stopwatch sw = Stopwatch.StartNew();
        Random rand = new Random();
        for (int i = 0; i < 10_000; i++)
        {
            int rnd = rand.Next(0, 1500);
            Assert.AreEqual(tasks[rnd], executor.GetByIndex(rnd));
        }
        // Assert
        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 150);

    }

}
