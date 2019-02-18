using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class Test16
{
    //Enumerator
    [TestCase]
    public void RA_ShouldBeEnumeratedIn_InsertionOrder()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "joro", 5, 5);
        Battlecard cd2 = new Battlecard(6, CardType.SPELL, "joro", 6, 5);
        Battlecard cd3 = new Battlecard(7, CardType.SPELL, "joro", 7, 5);
        List<Battlecard> expected = new List<Battlecard>()
        {
            cd1,cd3,cd2
        };
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        List<Battlecard> actual = RA.Take(RA.Count).ToList();
        //Assert
        CollectionAssert.AreEqual(expected, actual);
    }

}
