using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf6
{ 
    [TestCase]
    public void Contains_100000_Elements_ShouldExecuteFast()
    {
        // Arrange
        IScheduler executor = new ThreadExecutor();
        const int count = 100000;
        LinkedList<Task> tasks = new LinkedList<Task>();

        for (int i = 0; i < count; i++)
        {
            tasks.AddLast(new Task(i, i, Priority.HIGH));
            executor.Execute(tasks.Last.Value);
        }

        // Act
        Stopwatch sw = Stopwatch.StartNew();
        LinkedListNode<Task> node = tasks.First;
        while (node != null)
        {
            Assert.True(executor.Contains(node.Value));
            node = node.Next;
        }

        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 250);
    }
}
