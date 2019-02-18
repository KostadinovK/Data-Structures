using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Test42
{

    [TestCase]
    public void GetByCardTypeAndMaximumDamage_ShouldWorkCorrectly_AfterRemove()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(2, CardType.SPELL, "valq", 14.8, 53);
        Battlecard cd2 = new Battlecard(1, CardType.SPELL, "valq", 14.8, 5);
        Battlecard cd3 = new Battlecard(4, CardType.SPELL, "valq", 15.6, 6);
        Battlecard cd4 = new Battlecard(3, CardType.SPELL, "valq", 15.6, 12);
        Battlecard cd5 = new Battlecard(8, CardType.RANGED, "valq", 17.8, 613);
        List<Battlecard> expected = new List<Battlecard>()
        {
            cd2
        };
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        RA.RemoveById(cd1.Id);
        //Assert
        List<Battlecard> actual = RA
            .GetByCardTypeAndMaximumDamage(CardType.SPELL, 15.0)
            .ToList();
        CollectionAssert.AreEqual(expected, actual);
    }

}

