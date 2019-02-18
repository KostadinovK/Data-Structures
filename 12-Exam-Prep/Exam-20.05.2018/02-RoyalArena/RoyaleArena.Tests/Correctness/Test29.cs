using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Test29
{

    [TestCase]
    public void GetByName_On_NonExisting_Receiver_ShouldThrow()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        Battlecard cd1 = new Battlecard(2, CardType.SPELL, "pesho", 53, 1);
        Battlecard cd2 = new Battlecard(1, CardType.SPELL, "mesho", 5, 1);
        Battlecard cd3 = new Battlecard(4, CardType.SPELL, "kalin", 6, 15.6);
        Battlecard cd4 = new Battlecard(3, CardType.SPELL, "peshor", 6, 15.6);
        Battlecard cd5 = new Battlecard(8, CardType.RANGED, "barko", 7, 17.8);

        //Act
        RA.Add(cd1);
        RA.Add(cd3);
        RA.Add(cd2);
        RA.Add(cd4);
        RA.Add(cd5);
        //Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            RA.GetByNameOrderedBySwagDescending("mecho");
        });
    }

}

