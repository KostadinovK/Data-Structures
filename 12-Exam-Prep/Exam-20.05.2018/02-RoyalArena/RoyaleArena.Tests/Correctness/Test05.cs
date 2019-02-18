using System;
using NUnit.Framework;

public class Test05
{
    //Contains
    [TestCase]
    public void Contains_OnEmptyRoyaleArena_ShouldReturnFalse()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        //Act
        //Assert
        Assert.IsFalse(RA.Contains(new Battlecard(5, CardType.BUILDING, "kocho", 5, 6.2)));
        Assert.IsFalse(RA.Contains(new Battlecard(3, CardType.RANGED, "a", 6, 0.5)));
    }

}
