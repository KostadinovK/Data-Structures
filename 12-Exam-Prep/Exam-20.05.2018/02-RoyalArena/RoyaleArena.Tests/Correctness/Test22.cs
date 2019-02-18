using System;
using NUnit.Framework;

public class Test22
{

    [TestCase]
    public void FindFirstLeastSwag_OnNonExistantcds_ShouldThrow()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "joro", 5, 1);
        Battlecard cd2 = new Battlecard(6, CardType.MELEE, "joro", 5, 5.5);
        Battlecard cd3 = new Battlecard(7, CardType.MELEE, "joro", 10, 5.5);
        Battlecard cd4 = new Battlecard(12, CardType.RANGED, "joro", 11, 15.6);
        Battlecard cd5 = new Battlecard(15, CardType.SPELL, "joro", 16, 7.8);
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        //Assert
        Assert.Throws<InvalidOperationException>(
            () => RA.FindFirstLeastSwag(150)
        );
    }
}
