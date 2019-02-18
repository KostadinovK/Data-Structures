using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Test36
{
    [TestCase]
    public void GetAllByNameAndSwag_ShouldWorkCorrectly_AfterRemove()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(2, CardType.SPELL, "pesho", 5, 14.8);
        Battlecard cd2 = new Battlecard(1, CardType.SPELL, "pesho", 5, 14.9);
        Battlecard cd3 = new Battlecard(4, CardType.SPELL, "maru", 5, 15.6);
        Battlecard cd4 = new Battlecard(3, CardType.SPELL, "pesho", 5, 15.6);
        Battlecard cd5 = new Battlecard(8, CardType.RANGED, "pesho", 5, 17.8);
        List<Battlecard> expected = new List<Battlecard>()
        {
           cd2, cd3
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
        List<Battlecard> actual = RA.GetAllByNameAndSwag().ToList();
        CollectionAssert.AreEqual(expected, actual);
    }


}

