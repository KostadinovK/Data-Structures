using NUnit.Framework;
using System;

public class Test4
{
    [TestCase]
    public void Count_ThreadExecutor_ShouldIncrase()
    {

        //Arrange
        IScheduler executor = new ThreadExecutor();

        Task task1 = new Task(5, 1, Priority.EXTREME);
        Task task2 = new Task(6, 1, Priority.HIGH);
        Task task3 = new Task(12, 5, Priority.MEDIUM);
        Task task4 = new Task(51, 15, Priority.HIGH);
        Task task5 = new Task(5, 1, Priority.HIGH);

        //Act
        executor.Execute(task1);
        executor.Execute(task2);
        executor.Execute(task3);
        Assert.AreEqual(3, executor.Count);
        executor.Execute(task4);
        Assert.AreEqual(4, executor.Count);

        //Assert
        Assert.Throws<ArgumentException>(() => executor.Execute(task5));
        Assert.AreEqual(4, executor.Count);

    }

}

