using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class Test17
{
    [TestCase]
    public void RA_ShouldReturn_BattlecardsInCorrectOrder_AfterDelete()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "joro", 10, 5);
        Battlecard cd2 = new Battlecard(6, CardType.SPELL, "joro", 11, 5);
        Battlecard cd3 = new Battlecard(7, CardType.SPELL, "joro", 12, 5);
        List<Battlecard> expected = new List<Battlecard>()
        {
            cd2
        };
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.RemoveById(5);
        RA.RemoveById(7);
        List<Battlecard> actual = RA.Take(RA.Count).ToList();
        //Assert
        CollectionAssert.AreEqual(expected, actual);
    }

}
