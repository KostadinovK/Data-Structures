using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class Test21
{

    //FindFirstLeastSwag
    [TestCase]
    public void FindFirstLeastSwag_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "joro", 6, 1);
        Battlecard cd2 = new Battlecard(6, CardType.MELEE, "joro", 7, 5.5);
        Battlecard cd3 = new Battlecard(7, CardType.SPELL, "joro", 11, 5.5);
        Battlecard cd4 = new Battlecard(12, CardType.BUILDING, "joro", 12, 15.6);
        Battlecard cd5 = new Battlecard(15, CardType.BUILDING, "moro", 13, 7.8);
        List<Battlecard> expected = new List<Battlecard>()
        {
            cd1,cd2,cd3,cd5
        };
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        List<Battlecard> actual = RA
            .FindFirstLeastSwag(4)
            .ToList();
        //Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
