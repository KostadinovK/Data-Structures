using NUnit.Framework;
using System;

public class Test7
{

    [TestCase]
    public void FindByIndex_ThreadExecutor_ShouldThrowWhenOutOfBounds()
    {

        //Arrange
        IScheduler executor = new ThreadExecutor();
        //Act
        Task task1 = new Task(5, 6, Priority.HIGH);
        Task task2 = new Task(6, 2, Priority.LOW);
        executor.Execute(task1);
        executor.Execute(task2);

        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => executor.GetByIndex(-5));
        Assert.Throws<ArgumentOutOfRangeException>(() => executor.GetByIndex(5));

    }

}
