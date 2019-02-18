using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Test12
{

    [TestCase]
    public void Cycle_ThreadExecutor_ShouldReturnCorrectRemovalCount()
    {

        //Arange
        IScheduler executor = new ThreadExecutor();

        Task task1 = new Task(5, 5, Priority.HIGH);
        Task task2 = new Task(6, 5, Priority.LOW);
        Task task3 = new Task(7, 12, Priority.MEDIUM);
        Task task4 = new Task(12, 5, Priority.HIGH);
        Task task5 = new Task(15, 3, Priority.HIGH);
        Task task6 = new Task(19, 2, Priority.EXTREME);
        Task task7 = new Task(23, 16, Priority.LOW);
        Task task8 = new Task(73, 6, Priority.LOW);

        //Act
        executor.Execute(task1);
        executor.Execute(task2);
        executor.Execute(task3);
        executor.Execute(task4);
        executor.Execute(task5);
        executor.Execute(task6);
        executor.Execute(task7);
        executor.Execute(task8);

        //Assert
        Assert.AreEqual(8, executor.Count);
        List<Task> expectedStructure = new List<Task>() {
            task1, task2, task3, task4, task5, task6, task7, task8
        };
        List<Task> actualStructure = new List<Task>();
        executor.ToList().ForEach(x => actualStructure.Add(x));
        CollectionAssert.AreEqual(expectedStructure, actualStructure);
        Assert.Throws<ArgumentOutOfRangeException>(() => executor.GetByIndex(-5));

        int cycleCount = executor.Cycle(5);
        Assert.AreEqual(5, cycleCount);
        cycleCount = executor.Cycle(12);
        Assert.AreEqual(3, cycleCount);

        Assert.AreEqual(0, executor.Count);

        expectedStructure = new List<Task>() {
            
        };
        actualStructure = new List<Task>();
        executor.ToList().ForEach(x => actualStructure.Add(x));
        CollectionAssert.AreEqual(expectedStructure, actualStructure);
    }

}

