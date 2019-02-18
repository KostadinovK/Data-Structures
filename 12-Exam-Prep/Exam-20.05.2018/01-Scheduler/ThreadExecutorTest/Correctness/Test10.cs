using NUnit.Framework;
using System;

[TestFixture]
public class Test10
{

    [TestCase]
    public void Cycle_ThreadExecutor_ShouldWorkCorrectly()
    {

        //Arange
        IScheduler executor = new ThreadExecutor();

        Task task1 = new Task(5, 5, Priority.HIGH);
        Task task2 = new Task(6, 5, Priority.LOW);
        Task task3 = new Task(7, 12, Priority.MEDIUM);
        Task task4 = new Task(12, 5, Priority.HIGH);
        Task task5 = new Task(15, 3, Priority.LOW);
        Task task6 = new Task(19, 2, Priority.LOW);

        //Act
        executor.Execute(task1);
        executor.Execute(task2);
        executor.Execute(task3);
        executor.Execute(task4);
        executor.Execute(task5);
        executor.Execute(task6);

        Assert.AreEqual(6, executor.Count);
        executor.Cycle(3);
        Assert.AreEqual(4, executor.Count);
        Assert.Throws<ArgumentException>(() => executor.GetById(19));
        Assert.Throws<ArgumentException>(() => executor.GetById(15));
        executor.Cycle(5);

        //Assert
        Assert.AreEqual(1, executor.Count);
        Task t = executor.GetByIndex(0);
        Assert.AreSame(task3, t);
        Assert.Throws<ArgumentOutOfRangeException>(() => executor.GetByIndex(1));

    }

}
