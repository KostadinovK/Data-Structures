using NUnit.Framework;
using System;

class Test11
{
    [TestCase]
    public void Cycle_ThreadExecutor_ShouldThrowWhenEmpty()
    {

        //Arange
        IScheduler executor = new ThreadExecutor();

        //Act
        //Assert
        Assert.Throws<InvalidOperationException>(() => executor.Cycle(1));
    }
}

