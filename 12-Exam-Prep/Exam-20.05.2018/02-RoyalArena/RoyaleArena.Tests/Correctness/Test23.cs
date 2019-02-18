using System;
using NUnit.Framework;

public class Test23
{
    [TestCase]
    public void FindFirstLeastSwag_ShoudlThrowAfterRemove()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "joro", 5, 1);
        Battlecard cd2 = new Battlecard(6, CardType.SPELL, "joro", 6, 5.5);
        Battlecard cd3 = new Battlecard(7, CardType.SPELL, "joro", 7, 5.5);
        Battlecard cd4 = new Battlecard(12, CardType.SPELL, "joro", 8, 15.6);
        Battlecard cd5 = new Battlecard(15, CardType.RANGED, "joro", 12, 7.8);
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        RA.RemoveById(5);
        RA.RemoveById(7);
        RA.RemoveById(6);
        RA.RemoveById(12);
        RA.RemoveById(15);
        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.FindFirstLeastSwag(1);
        });
    }

}
