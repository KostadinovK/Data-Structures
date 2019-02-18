using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Test30
{
    [TestCase]
    public void GetByName_ShouldThrow_On_EmptyRA()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        //Act
        //Assert
        Assert.Throws<InvalidOperationException>(() => {
            RA.GetByNameOrderedBySwagDescending("pesho");
        });
    }



}

