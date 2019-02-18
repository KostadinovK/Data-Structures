using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Test27
{

    [TestCase]
    public void GetByTypeAndDamageRangeOrderedByDamageThenById_ShouldThrow_On_EmptyRA()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        //Act
        //Assert
        Assert.Throws<InvalidOperationException>(() => {
            RA.GetByTypeAndDamageRangeOrderedByDamageThenById(CardType.MELEE, 0, 20).ToList();
        });
    }


}

