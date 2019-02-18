using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class Test19
{
    [TestCase]
    public void GetAllInSwagRange_ShouldReturn_EmptyCollectionOnNonExistingRange()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "joro", 2, 1);
        Battlecard cd2 = new Battlecard(6, CardType.SPELL, "joro", 3, 2);
        Battlecard cd3 = new Battlecard(7, CardType.SPELL, "joro", 4, 5.5);
        Battlecard cd4 = new Battlecard(12, CardType.SPELL, "joro", 5, 15.6);
        Battlecard cd5 = new Battlecard(15, CardType.SPELL, "joro", 6, 7.8);
        List<Battlecard> expected = new List<Battlecard>();
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        List<Battlecard> actual = RA.GetAllInSwagRange(7.7, 7.75).ToList();
        //Assert
        CollectionAssert.AreEqual(expected, actual);
        RA.RemoveById(12);
        RA.RemoveById(15);
        actual = RA.GetAllInSwagRange(7.8, 16).ToList();
        CollectionAssert.AreEqual(expected, actual);
    }

}
