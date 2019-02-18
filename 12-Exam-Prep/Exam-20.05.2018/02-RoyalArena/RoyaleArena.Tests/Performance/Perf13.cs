using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using NUnit.Framework;

public class Perf13
{

    [TestCase]
    public void GetAllInSwagRange()
    {
        IArena ar = new RoyaleArena();
        List<Battlecard> cds = new List<Battlecard>();
        Random rand = new Random();
        for (int i = 0; i < 100000; i++)
        {
            Battlecard cd = new Battlecard(i, CardType.SPELL,
                "player", 550, i);
            ar.Add(cd);
            cds.Add(cd);
        }
        cds = cds.OrderBy(x => x.Swag).ThenBy(x => x.Id).ToList();
        int count = ar.Count;
        Assert.AreEqual(100000, count);
        Stopwatch watch = new Stopwatch();
        watch.Start();

        for (int i = 0; i < 100; i++)
        {
            IEnumerable<Battlecard> all = ar.GetAllInSwagRange(200, 600);
        }
        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.Less(l1, 150);
    }


}
