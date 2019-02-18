using System;
using NUnit.Framework;

public class Test12
{

    [TestCase]
    public void GetById_On_Empty_RoyaleArena_ShouldThrow()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        //Act
        //Assert
        Assert.Throws<InvalidOperationException>(() => RA.GetById(5));
    }

}
