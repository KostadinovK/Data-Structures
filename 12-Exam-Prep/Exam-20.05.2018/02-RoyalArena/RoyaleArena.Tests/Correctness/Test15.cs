using System;
using NUnit.Framework;

public class Test15
{

    [TestCase]
    public void ChangeCardType_On_NonExistingTranasction_ShouldThrow()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        //Act
        //Assert
        Assert.Throws<ArgumentException>(
            () => RA.ChangeCardType(6, CardType.RANGED)
        );
    }
}
