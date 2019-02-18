using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class Test25
{
    [TestCase]
    public void GetByTypeAndDamageRange_ShouldReturnCorrectRange_CorrectlyOrdered()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(2, CardType.SPELL, "joro", 1, 5);
        Battlecard cd2 = new Battlecard(1, CardType.SPELL, "joro", 1, 100);
        Battlecard cd3 = new Battlecard(4, CardType.SPELL, "joro", 15.6, 53);
        Battlecard cd4 = new Battlecard(3, CardType.SPELL, "joro", 15.6, 100);
        Battlecard cd5 = new Battlecard(8, CardType.SPELL, "joro", 17.8, 102);
        List<Battlecard> expected = new List<Battlecard>()
        {
            cd5, cd4, cd3, cd2, cd1
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
