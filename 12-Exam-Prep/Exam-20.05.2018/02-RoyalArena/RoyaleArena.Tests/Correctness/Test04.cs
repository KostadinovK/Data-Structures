using System;
using NUnit.Framework;

public class Test04
{
    [TestCase]
    public void Add_MultipleElements_RA_ShouldContainThemById()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "joro", 5, 5);
        Battlecard cd2 = new Battlecard(6, CardType.SPELL, "joro", 5, 5);
        Battlecard cd3 = new Battlecard(7, CardType.SPELL, "joro", 5, 5);
        //Act
        RA.Add(cd1);
        RA.Add(cd2);
        RA.Add(cd3);
        //Assert
        Assert.IsTrue(RA.Contains(cd1));
        Assert.IsTrue(RA.Contains(cd2));
        Assert.IsTrue(RA.Contains(cd3));
    }

}
