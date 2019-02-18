using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class Test20
{
    [TestCase]
    public void GetAllInSwagRange_ShouldReturnEmptyEnumeration_On_EmptyRA()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        //Act
        List<Battlecard> actual = RA.GetAllInSwagRange(7.7, 7.75).ToList();
        //Assert
        CollectionAssert.AreEqual(new List<Battlecard>(), actual);
    }

}
