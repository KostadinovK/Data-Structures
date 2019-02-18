using NUnit.Framework;
using System;
using System.Diagnostics;

public class Perf1
{
    [TestCase]
    public void Execute_ThreadExecutor_ShouldWorkFast()
    {

        //Arange

        const int items = 80_000;

        IScheduler executor = new ThreadExecutor();
        Stopwatch watch = new Stopwatch();

        //Act
        watch.Start();
        Random rand = new Random();
        for (int i = 0; i < items; i++)
        {
            executor.Execute(new Task(i, rand.Next(0, 2000), Priority.EXTREME));
        }
        watch.Stop();

        Assert.AreEqual(items, executor.Count);
        //Assert
        long elapsed = watch.ElapsedMilliseconds;

        Assert.Less(elapsed, 400);

    }
    
}
