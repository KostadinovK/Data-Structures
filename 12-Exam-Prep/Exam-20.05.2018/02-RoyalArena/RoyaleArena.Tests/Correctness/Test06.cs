using System;
using NUnit.Framework;

public class Test06
{

    [TestCase]
    public void Contains_OnExistingElement_ShouldReturnTrue()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "joro", 6, 5);
        Battlecard cd2 = new Battlecard(6, CardType.SPELL, "joro", 7, 5);
        Battlecard cd3 = new Battlecard(7, CardType.SPELL, "joro", 8, 5);
        //Act
        RA.Add(cd1);
        RA.Add(cd2);
        RA.Add(cd3);
        //Assert
        Assert.IsTrue(RA.Contains(cd1));
        Assert.IsFalse(RA.Contains(new Battlecard(3, CardType.BUILDING, "ta", 6, 52.2)));
        Assert.IsTrue(RA.Contains(cd2));
        Assert.IsFalse(RA.Contains(new Battlecard(0, CardType.RANGED, "b", 7, 5)));
    }

}
