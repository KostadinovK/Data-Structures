using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class Test14
{

    [TestCase]
    public void GetByConsumptionRange_ThreadExecutor_ShouldReturnAnEmptyCollection()
    {

        //Arange
        IScheduler executor = new ThreadExecutor();
        IScheduler executor2 = new ThreadExecutor();

        Task task1 = new Task(52, 5, Priority.HIGH);
        Task task2 = new Task(153, 7, Priority.LOW);

        //Act
        executor.Execute(task1);
        executor.Execute(task2);

        //Assert
        CollectionAssert.IsEmpty(executor2.GetByConsumptionRange(5, 6, true));
        CollectionAssert.AreEqual(new List<Task>(), executor.GetByConsumptionRange(6, 6, true));

    }

}

