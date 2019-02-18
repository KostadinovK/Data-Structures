using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using NUnit.Framework;

public class Perf14
{

    //GetAllReceiversWithCardType
    [TestCase]
    public void GetAllByNameAndSwag_ShouldWorkFast()
    {
        IArena ar = new RoyaleArena();
        Dictionary<string, Battlecard> max = new Dictionary<string, Battlecard>();
        CardType[] statuses = new CardType[]
        {
            CardType.MELEE,
            CardType.RANGED,
            CardType.SPELL,
            CardType.BUILDING
        };
        Random rand = new Random();
        Stopwatch sw = new Stopwatch();

        for (int i = 0; i < 100000; i++)
        {
            int status = rand.Next(0, 4);
            string name = rand.Next(0, 200).ToString();
            CardType TS = statuses[status];
            Battlecard cd = new Battlecard(i, TS,
                name, i, i);

            if (!max.ContainsKey(name))
            {
                max.Add(name, cd);
            }
            if (max[name].Swag <= cd.Swag)
            {
                max[name] = cd;
            }

            ar.Add(cd);
        }
        int count = ar.Count;
        Assert.AreEqual(100000, count);
        Stopwatch watch = new Stopwatch();

        watch.Start();
        for (int i = 0; i < 10; i++)
        {
            IEnumerable<Battlecard> all = ar.GetAllByNameAndSwag();
            foreach (var item in all)
            {
                Assert.AreSame(max[item.Name], item);
            }
        }
        watch.Stop();
        long l1 = watch.ElapsedMilliseconds;

        Assert.Less(l1, 150);
    }


}
