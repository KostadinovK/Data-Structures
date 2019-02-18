using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using NUnit.Framework;

public class Perf06
{

    //GetById
    [TestCase]
    public void GetById_ShouldWorkFast()
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
        for (int i = 0; i < 90000; i++)
        {
            int status = rand.Next(0, 4);
            Battlecard cd = new Battlecard(i, statuses[status],
                i.ToString(), i, i);
            ar.Add(cd);
            cds.Add(cd);
        }

        int count = ar.Count;
        Assert.AreEqual(90000, count);

        Stopwatch watch = new Stopwatch();
        watch.Start();

        foreach (Battlecard cd in cds)
        {
            Assert.AreSame(cd, ar.GetById(cd.Id));
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.Less(l1, 150);
    }

}
