using System;
using NUnit.Framework;

public class Test09
{
    [TestCase]
    public void Count_Should_RemainCorrect_AfterRemoving()
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
        RA.RemoveById(cd1.Id);
        RA.RemoveById(cd3.Id);
        //Assert
        Assert.AreEqual(1, RA.Count);
        Assert.AreNotSame(cd1, RA.GetById(cd2.Id));
    }


}
