using System;
using NUnit.Framework;

public class Test07
{

    //Count
    [TestCase]
    public void Count_Should_IncreaseOnMultiple_Elements()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "joro", 3, 5);
        Battlecard cd2 = new Battlecard(6, CardType.SPELL, "joro", 8, 5);
        Battlecard cd3 = new Battlecard(7, CardType.SPELL, "joro", 9, 5);
        //Act
        RA.Add(cd1);
        RA.Add(cd2);
        RA.Add(cd3);
        //Assert
        Assert.AreEqual(3, RA.Count);
    }

}
