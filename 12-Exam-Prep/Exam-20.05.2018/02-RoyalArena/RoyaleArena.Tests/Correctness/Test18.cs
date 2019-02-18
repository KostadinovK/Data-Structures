using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class Test18
{
    //GetAllInSwagRange
    [TestCase]
    public void GetInSwagRange_ShouldReturn_CorrectBattlecards()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "dragon", 8, 1);
        Battlecard cd2 = new Battlecard(6, CardType.SPELL, "raa", 7, 2);
        Battlecard cd3 = new Battlecard(7, CardType.SPELL, "maga", 6, 5.5);
        Battlecard cd4 = new Battlecard(12, CardType.SPELL, "shuba", 5, 15.6);
        Battlecard cd5 = new Battlecard(15, CardType.SPELL, "tanuki", 5, 7.8);
        List<Battlecard> expected = new List<Battlecard>()
        {
            cd5, cd4
        };
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        List<Battlecard> actual = RA.GetAllInSwagRange(7, 16).ToList();
        //Assert
        CollectionAssert.AreEqual(expected, actual);
    }

}
