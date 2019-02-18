using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using NUnit.Framework;

public class Perf01
{
    //Add (Show Visa that you are not to be reckoned with
    [TestCase]
    public void Add_100000_Battlecards_Should_WorkFast()
    {

        IArena ar = new RoyaleArena();
        Stopwatch sw = new Stopwatch();
        int count = 80_000;
        CardType[] statuses = new CardType[]
        {
            CardType.MELEE,
            CardType.RANGED,
            CardType.SPELL,
            CardType.BUILDING
        };
        Random rand = new Random();
        sw.Start();
        for (int i = 0; i < count; i++)
        {
            //int status = rand.Next(0, 4);
            ar.Add(new Battlecard(i, CardType.SPELL,
                i.ToString(), i, i));
        }

        sw.Stop();
        Assert.AreEqual(count, ar.Count);
        Assert.Less(sw.ElapsedMilliseconds, 400);
    }


}
