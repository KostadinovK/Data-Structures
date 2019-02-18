using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Test34
{

    [TestCase]
    public void GetByCardTypeAndMaximumDamage_ShouldThrowOnEmpty_RA()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        //Act
        //Assert
        Assert.Throws<InvalidOperationException>(() => {
            RA.GetByCardTypeAndMaximumDamage(CardType.MELEE, 5);
        });
    }

}

