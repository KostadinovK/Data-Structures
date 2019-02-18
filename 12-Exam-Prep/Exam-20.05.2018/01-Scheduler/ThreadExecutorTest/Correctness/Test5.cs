using NUnit.Framework;
using System;

public class Test5
{

    [TestCase]
    public void FindByIndex_ThreadExecutor_ShouldWorkCorrectly()
    {

        //Arrange
        IScheduler executor = new ThreadExecutor();
        Task task1 = new Task(5, 1, Priority.HIGH);
        Task task2 = new Task(6, 3, Priority.LOW);
        Task task3 = new Task(7, 6, Priority.LOW);
        Task task4 = new Task(8, 3, Priority.EXTREME);
        Task task5 = new Task(9, 5, Priority.MEDIUM);

        //Act
        executor.Execute(task1);
        executor.Execute(task2);
        executor.Execute(task4);
        executor.Execute(task5);
        executor.Execute(task3);

        //Assert
        Assert.AreEqual(5, executor.Count);
        Assert.AreSame(task1, executor.GetByIndex(0));
        Assert.AreSame(task2, executor.GetByIndex(1));
        Assert.AreSame(task4, executor.GetByIndex(2));
        Assert.AreSame(task5, executor.GetByIndex(3));
        Assert.AreSame(task3, executor.GetByIndex(4));

    }


}
