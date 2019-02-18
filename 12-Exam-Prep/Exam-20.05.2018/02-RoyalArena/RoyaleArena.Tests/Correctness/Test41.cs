using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Test41
{
    
    //GetByCardTypeAndMaximumDamage
    [TestCase]
    public void GetByCardTypeAndMaximumDamage_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(2, CardType.SPELL, "valq", 14, 5);
        Battlecard cd2 = new Battlecard(1, CardType.SPELL, "valq", 14, 5);
        Battlecard cd3 = new Battlecard(4, CardType.SPELL, "valq", 15, 6);
        Battlecard cd4 = new Battlecard(3, CardType.SPELL, "valq", 15, 7);
        Battlecard cd5 = new Battlecard(8, CardType.SPELL, "valq", 18, 8);
        List<Battlecard> expected = new List<Battlecard>()
        {
            cd4, cd3, cd2, cd1
        };
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        //Assert
        List<Battlecard> actual = RA
            .GetByCardTypeAndMaximumDamage(CardType.SPELL, 17)
            .ToList();
        CollectionAssert.AreEqual(expected, actual);
    }

}

