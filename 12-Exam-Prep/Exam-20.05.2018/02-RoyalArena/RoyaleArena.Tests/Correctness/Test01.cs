using System;
using NUnit.Framework;

public class Test01
{
    //Addition
    [TestCase]
    public void Add_SingleElement_ShouldWorkCorrectly()
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
    }

}
