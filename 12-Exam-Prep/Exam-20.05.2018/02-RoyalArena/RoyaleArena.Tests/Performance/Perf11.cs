using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using NUnit.Framework;

public class Perf11
{

    //GetByNameOrderedBySwagDescending
    [TestCase]
    public void GetByNameAndSwagRange_ShouldWorkFast()
    {
        IArena ar = new RoyaleArena();
        List<List<Battlecard>> cds = new List<List<Battlecard>>();
        List<Tuple<int, int>> ranges = new List<Tuple<int, int>>();
        Random rand = new Random();
        int id = 0;
        for (int i = 0; i < 100; i++)
        {
            Tuple<int, int> range = new Tuple<int, int>(rand.Next(100, 400), rand.Next(500, 1000));
            ranges.Add(range);
            List<Battlecard> cd = new List<Battlecard>();
            for (int j = 0; j < 100; j++)
            {
                int amount = rand.Next(range.Item1 + 1, range.Item2 - 1);
                id++;
                Battlecard card = new Battlecard(id, CardType.SPELL,
                    i.ToString(), i, amount);
                cd.Add(card);
                ar.Add(card);
            }
            cds.Add(cd.OrderByDescending(x => x.Swag).ThenBy(x => x.Id).ToList());
        }

        int count = ar.Count;
        Assert.AreEqual(10000, count);
        Stopwatch watch = new Stopwatch();
        watch.Start();

        List<IEnumerable<Battlecard>> results = new List<IEnumerable<Battlecard>>();
        for (int i = 0; i < 100; i++)
        {
            Tuple<int, int> range = ranges[i];
            IEnumerable<Battlecard> all = ar.GetByNameAndSwagRange(i.ToString(), range.Item1, range.Item2);
            results.Add(all);
        }
        watch.Stop();
        int c = 0;
        for (int i = 0; i < 100; i++)
        {
            CollectionAssert.AreEqual(cds[i], results[i].ToList());
            c++;
        }

        long l1 = watch.ElapsedMilliseconds;

        Assert.Less(l1, 150);
        Assert.AreEqual(cds.Count, c);
    }

}
