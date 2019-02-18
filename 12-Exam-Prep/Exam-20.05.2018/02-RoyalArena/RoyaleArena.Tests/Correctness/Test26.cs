using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Test26
{

    [TestCase]
    public void GetByTypeAndDamageRangeOrderedByDamageThenById_ShouldThrow_AfterRemovingReceiver()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(5, CardType.SPELL, "joro", 1, 5);
        Battlecard cd2 = new Battlecard(6, CardType.RANGED, "joro", 5.5, 5);
        Battlecard cd3 = new Battlecard(7, CardType.MELEE, "joro", 5.5, 10);
        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.RemoveById(5);
        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.GetByTypeAndDamageRangeOrderedByDamageThenById(CardType.SPELL, 0, 20).ToList();
        });

    }


}

