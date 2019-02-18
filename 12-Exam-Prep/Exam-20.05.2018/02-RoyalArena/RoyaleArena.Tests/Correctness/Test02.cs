using System;
using NUnit.Framework;

public class Test02
{
    [TestCase]
    public void Add_SingleElement_ShouldIncreaseCountTo1()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd = new Battlecard(5, CardType.SPELL, "joro", 5, 5);
        //Act
        RA.Add(cd);

        //Assert
        foreach (var Battlecard in RA)
        {
            Assert.AreSame(Battlecard, cd);
        }

        Assert.AreEqual(1, RA.Count);
    }

}
