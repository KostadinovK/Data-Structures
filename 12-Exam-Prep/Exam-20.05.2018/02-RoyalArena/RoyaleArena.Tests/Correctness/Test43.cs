using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Test43
{

    [TestCase]
    public void GetByCardTypeAndMaximumDamage_ShouldThrow_OnEmptyCollection()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(2, CardType.SPELL, "valq", 14.8, 6);
        Battlecard cd2 = new Battlecard(1, CardType.SPELL, "valq", 14.8, 7);
        Battlecard cd3 = new Battlecard(4, CardType.SPELL, "valq", 15.6, 8);
        Battlecard cd4 = new Battlecard(3, CardType.SPELL, "valq", 15.6, 9);
        Battlecard cd5 = new Battlecard(8, CardType.RANGED, "valq", 17.8, 10);
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        //Assert
        Assert.Throws<InvalidOperationException>(
            () => RA.GetByCardTypeAndMaximumDamage(CardType.BUILDING, 5)
            );
        RA = new RoyaleArena();
    }

}

