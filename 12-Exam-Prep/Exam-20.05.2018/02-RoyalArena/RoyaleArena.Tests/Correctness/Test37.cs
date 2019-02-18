using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Test37
{

    [TestCase]
    public void GetAllByNameAndSwag_ShouldReturnEmptyEnumeration_EmptyArena()
    {
        //Arrange
        IArena RA = new RoyaleArena();
        //Act
        //Assert
        List<Battlecard> actual = RA
            .GetAllByNameAndSwag()
            .ToList();
        CollectionAssert.AreEqual(new List<Battlecard>(), actual);
    }

}

