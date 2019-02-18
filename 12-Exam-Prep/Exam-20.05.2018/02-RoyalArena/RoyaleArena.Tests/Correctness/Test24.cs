using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class Test24
{
    //GetByTypeAndDamageRangeOrderedByDamageThenById
    [TestCase]
    public void GetByTypeAndDamageRangeOrderedByDamageThenById_ShouldWorkCorrectly_On_CorrectRange()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "joro", 1, 5);
        Battlecard cd2 = new Battlecard(6, CardType.SPELL, "joro", 5.5, 6);
        Battlecard cd3 = new Battlecard(7, CardType.SPELL, "joro", 5.5, 7);
        Battlecard cd4 = new Battlecard(12, CardType.SPELL, "joro", 15.6, 10);
        Battlecard cd5 = new Battlecard(15, CardType.RANGED, "joro", 7.8, 6);
        List<Battlecard> expected = new List<Battlecard>()
        {
            cd4, cd2, cd3, cd1
        };
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        //Assert
        List<Battlecard> actual = RA.GetByTypeAndDamageRangeOrderedByDamageThenById(CardType.SPELL, 0, 20).ToList();
        CollectionAssert.AreEqual(expected, actual);

    }

}
