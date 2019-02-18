using System;
using NUnit.Framework;

public class Test2
{

    [TestCase]
    public void Addition_ThreadExecutor_ShouldAddCorrectTasks()
    {
        //Arrange
        IScheduler executor = new ThreadExecutor();
        Task task1 = new Task(5, 1, Priority.EXTREME);
        Task task2 = new Task(6, 5, Priority.HIGH);
        Task task3 = new Task(12, 12, Priority.LOW);

        //Act
        executor.Execute(task1);
        executor.Execute(task2);
        executor.Execute(task3);

        //Assert
        Task result1 = executor.GetByIndex(0);
        Task result2 = executor.GetByIndex(1);
        Task result3 = executor.GetByIndex(2);

        Assert.AreSame(task1, result1);
        Assert.AreSame(task2, result2);
        Assert.AreSame(task3, result3);

    }

}
