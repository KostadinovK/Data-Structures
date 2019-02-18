using System;
using NUnit.Framework;

public class Test13
{
    //ChangecdStatus
    [TestCase]
    public void ChangeCardType_ShouldWorkCorrectly_On_Existingcd()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "joro", 10, 5);
        Battlecard cd2 = new Battlecard(6, CardType.SPELL, "joro", 10, 5);
        Battlecard cd3 = new Battlecard(7, CardType.SPELL, "joro", 10, 5);
        //Act
        RA.Add(cd1);
        RA.Add(cd2);
        RA.Add(cd3);
        RA.ChangeCardType(5, CardType.MELEE);
        //Assert
        Assert.AreEqual(CardType.MELEE, cd1.Type);
        Assert.AreEqual(3, RA.Count);
    }

}
