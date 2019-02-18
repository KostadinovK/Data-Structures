using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Test39
{


    [TestCase]
    public void GetByCardType_ShouldReturnCorrectResult()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(2, CardType.SPELL, "valq", 6, 14.8);
        Battlecard cd2 = new Battlecard(1, CardType.SPELL, "valq", 6, 14.8);
        Battlecard cd3 = new Battlecard(4, CardType.SPELL, "valq", 7, 15.6);
        Battlecard cd4 = new Battlecard(3, CardType.RANGED, "valq", 8, 15.6);
        Battlecard cd5 = new Battlecard(8, CardType.SPELL, "valq", 9, 17.8);
        List<Battlecard> expected = new List<Battlecard>()
        {
           cd5, cd3, cd2, cd1
        };
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        //Assert
        List<Battlecard> actual = RA
            .GetByCardType(CardType.SPELL)
            .ToList();
        CollectionAssert.AreEqual(expected, actual);
    }

}

