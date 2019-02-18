using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using NUnit.Framework;

public class Perf07
{

    //GetBycdStatus
    [TestCase]
    public void GetByCardType_ShouldWorkFast()
    {
        IArena ar = new RoyaleArena();
        List<Battlecard> cds = new List<Battlecard>();
        Random rand = new Random();
        for (int i = 0; i < 100000; i++)
        {
            int amount = rand.Next(0, 50000);
            Battlecard cd = new Battlecard(i, CardType.SPELL,
                i.ToString(), i, amount);

            ar.Add(cd);
            cds.Add(cd);
        }

        int count = ar.Count;
        Assert.AreEqual(100000, count);
        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<Battlecard> byStatus = ar.GetByCardType(
            CardType.SPELL);
        int c = 0;

        foreach (Battlecard employee in byStatus)
        {
            c++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.Less(l1, 160);
        Assert.AreEqual(100000, c);
    }

}
