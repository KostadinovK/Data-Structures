using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using NUnit.Framework;

public class Perf05
{

    //RemoveById
    [TestCase]
    public void RemoveById_ShoudlWorkFast()
    {

        IArena ar = new RoyaleArena();
        List<Battlecard> cds = new List<Battlecard>();
        Random rand = new Random();
        for (int i = 0; i < 40_000; i++)
        {
            int amount = rand.Next(0, 60000);
            Battlecard cd = new Battlecard(i, CardType.SPELL,
                i.ToString(), i, amount);
            ar.Add(cd);
            cds.Add(cd);
        }

        int count = ar.Count;
        Assert.AreEqual(40000, count);

        Stopwatch watch = new Stopwatch();
        watch.Start();

        foreach (Battlecard cd in cds)
        {
            ar.RemoveById(cd.Id);
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;
        Assert.Less(l1, 300);
    }

}
