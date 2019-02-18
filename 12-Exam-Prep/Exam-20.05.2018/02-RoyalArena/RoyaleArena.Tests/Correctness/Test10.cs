using System;
using NUnit.Framework;

public class Test10
{

    //GetById
    [TestCase]
    public void GetById_On_ExistingElement_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "joro", 10, 5);
        Battlecard cd2 = new Battlecard(6, CardType.SPELL, "joro", 10, 5);
        Battlecard cd3 = new Battlecard(7, CardType.SPELL, "joro", 10, 5);
        //Act
        RA.Add(cd1);
        RA.Add(cd2);
        RA.Add(cd3);
        //Assert
        Assert.AreSame(cd1, RA.GetById(5));
        Assert.AreNotSame(
            new Battlecard(53, CardType.RANGED, "a", 10, 5),
            RA.GetById(7)
        );
    }
}
