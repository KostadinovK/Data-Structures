using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Test28
{

    [TestCase]
    public void Enumerator_ThreadExecutor_ShouldReturnEmptyCollection()
    {

        //Arange
        IScheduler executor = new ThreadExecutor();

        Task task1 = new Task(52, 5, Priority.HIGH);
        Task task2 = new Task(56, 12, Priority.HIGH);

        List<Task> expected = new List<Task>();
        //Act
        Assert.AreEqual(0, executor.Count);

        //Assert
        List<Task> actual = executor.ToList();

        CollectionAssert.AreEqual(expected, actual);

    }

}
