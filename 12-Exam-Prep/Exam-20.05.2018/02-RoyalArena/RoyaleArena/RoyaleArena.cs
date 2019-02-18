using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class RoyaleArena : IArena
{
    public int Count => throw new NotImplementedException();

    public void Add(Battlecard card)
    {
        throw new NotImplementedException();
    }

    public void ChangeCardType(int id, CardType type)
    {
        throw new NotImplementedException();
    }

    public bool Contains(Battlecard card)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> FindFirstLeastSwag(int n)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetAllByNameAndSwag()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetAllInSwagRange(double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetByCardType(CardType type)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
    {
        throw new NotImplementedException();
    }

    public Battlecard GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetByNameAndSwagRange(string name, double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetByNameOrderedBySwagDescending(string name)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Battlecard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<Battlecard> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void RemoveById(int id)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
