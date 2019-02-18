using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Test33
{
    [TestCase]
    public void GetByCardTypeAndMaximumDamage_ShouldOrderAndPickCorrectly()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(2, CardType.SPELL, "joro", 1, 6);
        Battlecard cd2 = new Battlecard(1, CardType.RANGED, "valq", 14.8, 7);
        Battlecard cd3 = new Battlecard(4, CardType.RANGED, "valq", 15.6, 6);
        Battlecard cd4 = new Battlecard(3, CardType.RANGED, "valq", 15.6, 12);
        Battlecard cd5 = new Battlecard(8, CardType.RANGED, "valq", 17.8, 63);
        List<Battlecard> expected = new List<Battlecard>()
        {
           cd3, cd2
        };
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        RA.RemoveById(8);
        RA.RemoveById(3);
        //Assert
        List<Battlecard> actual = RA.GetByCardTypeAndMaximumDamage(CardType.RANGED, 15.6).ToList();
        CollectionAssert.AreEqual(expected, actual);
    }


}

