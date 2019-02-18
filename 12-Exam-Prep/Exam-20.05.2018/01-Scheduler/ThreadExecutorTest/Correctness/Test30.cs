using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test30
{

    [TestCase]
    public void GetByPriorityAndMinimumConsumption_ThreadExecutor_ShouldWorkCorrectly_AfterCycle()
    {

        //Arange
        IScheduler executor = new ThreadExecutor();

        Task task1 = new Task(52, 5, Priority.LOW);
        Task task2 = new Task(56, 12, Priority.LOW);
        Task task3 = new Task(58, 12, Priority.LOW);
        Task task4 = new Task(100, 14, Priority.LOW);
        Task task5 = new Task(600, 15, Priority.LOW);
        Task task6 = new Task(12, 5, Priority.LOW);
        Task task7 = new Task(125, 6, Priority.LOW);
        Task task8 = new Task(0, 8, Priority.EXTREME);
        List<Task> expected = new List<Task>()
        {
           task5
        };

        //Act
        executor.Execute(task1);
        executor.Execute(task2);
        executor.Execute(task3);
        executor.Execute(task4);
        executor.Execute(task5);
        executor.Execute(task6);
        executor.Execute(task7);
        executor.Execute(task8);
        
        Assert.AreEqual(8, executor.Count);

        executor.Cycle(5);
        executor.Cycle(5);
        executor.Cycle(4);

        //Assert
        List<Task> actual = executor.GetByPriorityAndMinimumConsumption(Priority.LOW, 10).ToList();

        CollectionAssert.AreEqual(expected, actual);

    }

}
