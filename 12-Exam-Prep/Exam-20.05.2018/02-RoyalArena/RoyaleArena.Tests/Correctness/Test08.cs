using System;
using NUnit.Framework;

public class Test08
{

    [TestCase]
    public void Count_Should_Be_0_On_EmptyCollection()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        //Act
        //Assert
        Assert.AreEqual(0, RA.Count);
    }

}
