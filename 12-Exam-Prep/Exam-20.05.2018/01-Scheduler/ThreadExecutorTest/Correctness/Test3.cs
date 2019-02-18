using NUnit.Framework;
using System;

public class Test3
{
    [TestCase]
    public void AddingExistingId_ThreadExecutor_ShouldThrowException()
    {

        //Arrange
        IScheduler executor = new ThreadExecutor();

        Task task1 = new Task(5, 1, Priority.EXTREME);
        Task task2 = new Task(6, 1, Priority.HIGH);
        Task task3 = new Task(12, 5, Priority.MEDIUM);
        Task task4 = new Task(12, 5, Priority.HIGH);

        //Act
        executor.Execute(task1);
        executor.Execute(task2);
        executor.Execute(task3);

        //Assert
        Assert.AreEqual(3, executor.Count);
        Assert.Throws<ArgumentException>(() => executor.Execute(task4));
    }

}

