using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using NUnit.Framework;

public class Perf10
{

    //GetByCardTypeAndMaximumAmount
    [TestCase]
    public void GetByCardTypeAndMaximumDamage_ShouldWorkFast()
    {
        IArena ar = new RoyaleArena();
        List<Battlecard> cds = new List<Battlecard>();
        Random rand = new Random();
        for (int i = 0; i < 100000; i++)
        {
            int amount = rand.Next(0, 1000);
            Battlecard cd = new Battlecard(i, CardType.SPELL,
                i.ToString(), amount, i);
            ar.Add(cd);
            if (amount <= 500) cds.Add(cd);
        }
        cds = cds.OrderByDescending(x => x.Damage).ThenBy(x => x.Id).ToList();
        int count = ar.Count;
        Assert.AreEqual(100000, count);
        Stopwatch watch = new Stopwatch();
        watch.Start();

        IEnumerable<Battlecard> all = ar.GetByCardTypeAndMaximumDamage(
            CardType.SPELL, 500);
        int c = 0;
        foreach (Battlecard cd in all)
        {
            Assert.AreSame(cd, cds[c]);
            c++;
        }

        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.Less(l1, 150);
        Assert.AreEqual(cds.Count, c);
    }

}
