using NUnit.Framework;
using System;

public class UnitTest1
{
    [TestCase]
    public void AddingTask_ThreadExecutor_CountShouldIncrease()
    {
        //Arrange
        Task task1 = new Task(52, 12, Priority.EXTREME);
        Task task2 = new Task(13, 66, Priority.HIGH);

        IScheduler executor = new ThreadExecutor();

        //Act
        executor.Execute(task1);
        executor.Execute(task2);

        //Assert
        Assert.AreEqual(2, executor.Count);

    }
}
