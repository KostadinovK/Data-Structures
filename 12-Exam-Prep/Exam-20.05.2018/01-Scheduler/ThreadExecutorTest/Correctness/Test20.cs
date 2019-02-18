using NUnit.Framework;
using System;

[TestFixture]
public class Test20
{

    [TestCase]
    public void Contains_ThreadExecutor_ShouldWorkCorrectly()
    {

        //Arrange
        IScheduler executor = new ThreadExecutor();

        Task task1 = new Task(52, 12, Priority.EXTREME);
        Task task2 = new Task(13, 66, Priority.HIGH);

        //Act
        executor.Execute(task1);
        executor.Execute(task2);

        //Assert
        Assert.AreEqual(2, executor.Count);
        Assert.True(executor.Contains(task2));

    }

}
