using NUnit.Framework;
using System;

public class Test6
{

    [TestCase]
    public void FindByIndex_ThreadExecutor_ShouldThrowWhenEmpty()
    {

        //Arrange
        IScheduler executor = new ThreadExecutor();
        //Act
        //Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => executor.GetByIndex(0));
    }

}
