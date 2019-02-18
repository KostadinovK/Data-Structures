using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test31
{

    [TestCase]
    public void GetByPriorityAndMinimumConsumption_ThreadExecutor_ShouldReturnEmptyCollection()
    {

        //Arange
        IScheduler executor = new ThreadExecutor();

        Task task1 = new Task(52, 5, Priority.LOW);
        Task task2 = new Task(56, 12, Priority.HIGH);
        Task task3 = new Task(58, 12, Priority.LOW);
        Task task4 = new Task(100, 51, Priority.HIGH);
        Task task5 = new Task(600, 15, Priority.MEDIUM);
        Task task6 = new Task(12, 5, Priority.EXTREME);
        Task task7 = new Task(125, 6, Priority.MEDIUM);
        Task task8 = new Task(0, 8, Priority.HIGH);
        List<Task> expected = new List<Task>();

        //Act
        executor.Execute(task1);
        executor.Execute(task2);
        executor.Execute(task3);
        executor.Execute(task4);
        executor.Execute(task5);
        executor.Execute(task6);
        executor.Execute(task7);
        executor.Execute(task8);

        executor.ChangePriority(56, Priority.LOW);
        executor.ChangePriority(52, Priority.HIGH);

        executor.Cycle(12);
        //Assert
        List<Task> actual = executor.GetByPriorityAndMinimumConsumption(Priority.LOW, 10).ToList();

        CollectionAssert.AreEqual(expected, actual);

    }

}
