using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using NUnit.Framework;

public class Perf09
{

    //FindFirstLeastSwag
    [TestCase]
    public void FindFirstLeastSwag_ShouldWorkFast()
    {
        IArena ar = new RoyaleArena();
        List<Battlecard> cds = new List<Battlecard>();
        for (int i = 0; i < 100000; i++)
        {
            Battlecard cd = new Battlecard(i, CardType.SPELL,
                i.ToString(), i, i);
            ar.Add(cd);
            cds.Add(cd);
        }
        cds = cds.OrderBy(x => x.Swag).ToList();
        List<int> ns = new List<int>();
        List<List<Battlecard>> expected = new List<List<Battlecard>>();
        Random rand = new Random();
        for (int i = 0; i < 100; i++)
        {
            int n = rand.Next(0, 5000);
            ns.Add(n);
            expected.Add(cds.Take(n).ToList());
        }

        int count = ar.Count;
        cds = cds.OrderByDescending(x => x.Damage).ThenBy(x => x.Id).ToList();
        Assert.AreEqual(100000, count);
        Stopwatch watch = new Stopwatch();
        watch.Start();

        List<IEnumerable<Battlecard>> actual = new List<IEnumerable<Battlecard>>();
        for (int i = 0; i < 100; i++)
        {
            IEnumerable<Battlecard> all = ar.FindFirstLeastSwag(ns[i]);
            actual.Add(all);
        }
        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.Less(l1, 300);

        for (int i = 0; i < 100; i++)
        {
            CollectionAssert.AreEqual(expected[i], actual[i].ToList());
        }

    }

}
