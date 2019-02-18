using NUnit.Framework;
using System;

[TestFixture]
public class Test22
{

    [TestCase]
    public void Contains_ThreadExecutor_ShouldWorkCorrectly_AfterCycle()
    {

        //Arrange
        IScheduler executor = new ThreadExecutor();

        Task task1 = new Task(52, 12, Priority.EXTREME);
        Task task2 = new Task(13, 8, Priority.HIGH);

        //Act
        executor.Execute(task2);

        //Assert
        Assert.AreEqual(1, executor.Count);
        Assert.False(executor.Contains(task1));

    }

}
