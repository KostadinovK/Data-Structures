using System;
using NUnit.Framework;

public class Test14
{
    [TestCase]
    public void ChangeCardType_OnMultipleBattlecards_ShouldWorkCorrectly()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "joro", 5, 5);
        Battlecard cd2 = new Battlecard(6, CardType.SPELL, "joro", 6, 5);
        Battlecard cd3 = new Battlecard(7, CardType.SPELL, "joro", 7, 5);
        //Act
        RA.Add(cd1);
        RA.Add(cd2);
        RA.Add(cd3);
        RA.ChangeCardType(7, CardType.BUILDING);
        RA.ChangeCardType(5, CardType.MELEE);
        RA.ChangeCardType(6, CardType.SPELL);
        //Assert
        Assert.AreEqual(3, RA.Count);
        Assert.AreEqual(cd1.Type, CardType.MELEE);
        Assert.AreEqual(cd3.Type, CardType.BUILDING);
        Assert.AreEqual(cd2.Type, CardType.SPELL);
    }

}
