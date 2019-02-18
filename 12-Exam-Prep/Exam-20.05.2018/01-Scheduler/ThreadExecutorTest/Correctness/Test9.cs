using NUnit.Framework;
using System;

class Test9
{
    [TestCase]
    public void FindById_ThreadExecutor_OnNonExistingId_ShouldThrow()
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

        //Assert
        Assert.AreEqual(4, executor.Count);
        Assert.Throws<ArgumentException>(() => executor.GetById(12));

    }
}
