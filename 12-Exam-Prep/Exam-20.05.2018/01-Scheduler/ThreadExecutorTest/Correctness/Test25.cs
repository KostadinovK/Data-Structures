using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class Test25
{

    [TestCase]
    public void ChangePriority_ThreadExecutor_ShouldThrow_On_InvalidArgument()
    {

        //Arange
        IScheduler executor = new ThreadExecutor();

        //Act

        //Assert
        Assert.Throws<ArgumentException>(() =>  executor.ChangePriority(600, Priority.HIGH));


    }

}
