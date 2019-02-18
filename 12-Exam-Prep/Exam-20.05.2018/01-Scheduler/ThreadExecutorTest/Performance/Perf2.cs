using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;

[TestFixture]
public class Perf2
{

    [TestCase]
    public void FindById_ThreadExecutor_ShouldWorkFast()
    {
        // Arrange
        IScheduler executor = new ThreadExecutor();
        const int count = 100000;
        LinkedList<Task> tasks = new LinkedList<Task>();

        for (int i = 0; i < count; i++)
        {
            tasks.AddLast(new Task(i + 1, i, Priority.HIGH));
            executor.Execute(tasks.Last.Value);
        }

        // Act
        Stopwatch sw = Stopwatch.StartNew();
        LinkedListNode<Task> node = tasks.First;
        while (node != null)
        {
            Assert.AreSame(node.Value, executor.GetById(node.Value.Id));
            node = node.Next;
        }

        sw.Stop();
        Assert.Less(sw.ElapsedMilliseconds, 250);
    }

}
