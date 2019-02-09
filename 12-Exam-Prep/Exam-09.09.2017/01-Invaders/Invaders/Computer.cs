using System;
using System.Collections.Generic;
using System.Linq;

public class Computer : IComputer
{
    private int energy;
    
    private HashSet<Invader> invaders;

    public Computer(int energy)
    {
        if (energy < 0)
        {
            throw new ArgumentException();
        }

        this.energy = energy;
        invaders = new HashSet<Invader>();
    }

    public int Energy
    {
        get => Math.Max(0, energy);
    }

    public void Skip(int turns)
    {
        List<Invader> toRemove = new List<Invader>();
        foreach (var invader in invaders)
        {
            invader.Distance -= turns;

            if (invader.Distance <= 0)
            {
                if (energy >= 0)
                {
                    energy -= invader.Damage;
                }

                toRemove.Add(invader);
            }
        }

        toRemove.ForEach(x => invaders.Remove(x));
    }

    public void AddInvader(Invader invader)
    {
        invaders.Add(invader);
    }

    public void DestroyHighestPriorityTargets(int count)
    {
        var toDestroy = invaders.OrderBy(x => x.Distance).ThenByDescending(x => x.Damage).Take(count).ToList();

        toDestroy.ForEach(x => invaders.Remove(x));
    }

    public void DestroyTargetsInRadius(int radius)
    {
         var toDestroy = invaders.Where(x => x.Distance <= radius).ToList();
         
         toDestroy.ForEach(x => invaders.Remove(x));
    }

    public IEnumerable<Invader> Invaders()
    {
        return invaders;
    }
}
