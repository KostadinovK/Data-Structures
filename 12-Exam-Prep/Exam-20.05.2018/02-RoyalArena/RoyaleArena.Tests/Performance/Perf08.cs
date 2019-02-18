using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using NUnit.Framework;

public class Perf08
{

    //GetByNameOrderedBySwagDescending
    [TestCase]
    public void GetByNameOrderedBySwagDescending_ShouldWorkFast()
    {
        IArena ar = new RoyaleArena();
        List<Battlecard> cds = new List<Battlecard>();
        for (int i = 0; i < 100000; i++)
        {
            Battlecard cd = new Battlecard(i, CardType.SPELL,
                "player", i, i);
            ar.Add(cd);
            cds.Add(cd);
        }

        int count = ar.Count;
        cds = cds.OrderByDescending(x => x.Swag).ToList();
        Assert.AreEqual(100000, count);
        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<Battlecard> all = ar.GetByNameOrderedBySwagDescending("player");
        int c = 0;
        foreach (Battlecard cd in all)
        {
            Assert.AreSame(cd, cds[c]);
            c++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.Less(l1, 250);
        Assert.AreEqual(100000, c);
    }

}
