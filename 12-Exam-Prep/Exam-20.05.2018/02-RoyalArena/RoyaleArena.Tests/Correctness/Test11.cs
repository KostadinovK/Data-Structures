using System;
using NUnit.Framework;

public class Test11
{

    [TestCase]
    public void GetById_On_NonExistingElement_ShouldThrow()
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
        RA.RemoveById(5);
        //Assert
        Assert.Throws<InvalidOperationException>(() => RA.GetById(5));
    }
}
