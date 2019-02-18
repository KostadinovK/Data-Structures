using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using NUnit.Framework;

public class Perf04
{

    //ChangeCardType
    [TestCase]
    public void ChangeCardType_ShouldWorkFast()
    {
        IArena ar = new RoyaleArena();
        CardType[] statuses = new CardType[]
        {
            CardType.MELEE,
            CardType.RANGED,
            CardType.SPELL,
            CardType.BUILDING
        };
        Random rand = new Random();
        List<Battlecard> cds = new List<Battlecard>();
        for (int i = 0; i < 80_000; i++)
        {
            int status = rand.Next(0, 4);
            Battlecard cd = new Battlecard(i, statuses[status],
                i.ToString(), i, i);
            ar.Add(cd);
            cds.Add(cd);
        }

        int count = ar.Count;
        Assert.AreEqual(80_000, count);

        Stopwatch watch = new Stopwatch();
        watch.Start();

        foreach (Battlecard cd in cds)
        {
            int status = rand.Next(0, 4);
            ar.ChangeCardType(cd.Id, statuses[status]);
            Assert.AreEqual(statuses[status], ar.GetById(cd.Id).Type);
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;
        Assert.Less(l1, 350);
    }

}
