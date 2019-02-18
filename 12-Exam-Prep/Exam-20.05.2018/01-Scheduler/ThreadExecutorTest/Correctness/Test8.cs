using NUnit.Framework;
using System;

public class Test8
{

    [TestCase]
    public void FindById_ThreadExecutor_ShouldWorkCorrectly()
    {

        //Arrange
        IScheduler executor = new ThreadExecutor();
        Task task1 = new Task(5, 6, Priority.HIGH);
        Task task2 = new Task(6, 2, Priority.LOW);
        Task task3 = new Task(7, 4, Priority.LOW);
        Task task4 = new Task(0, 56, Priority.EXTREME);
        Task task5 = new Task(0, 56, Priority.EXTREME);

        //Act
        executor.Execute(task1);
        executor.Execute(task2);
        executor.Execute(task3);
        executor.Execute(task4);

        Task result1 = executor.GetById(5);
        Task result2 = executor.GetById(6);
        Task result3 = executor.GetById(7);
        Task result4 = executor.GetById(0);

        //Assert
        Assert.AreSame(result1, task1);
        Assert.AreSame(result2, task2);
        Assert.AreSame(result3, task3);
        Assert.AreSame(result4, task4);
        Assert.AreNotSame(result4, task5);
    }


}

