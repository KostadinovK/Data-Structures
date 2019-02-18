using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class RoyaleArena : IArena
{
    private Dictionary<int, Battlecard> byId;
    private List<Battlecard> byInsertion;
    private Dictionary<string, OrderedBag<Battlecard>> byName;

    public RoyaleArena()
    {
        byId = new Dictionary<int, Battlecard>();
        byInsertion = new List<Battlecard>();
        byName = new Dictionary<string, OrderedBag<Battlecard>>();
    }

    public int Count => byId.Count;

    public void Add(Battlecard card)
    {
        byId.Add(card.Id, card);
        byInsertion.Add(card);
        if (!byName.ContainsKey(card.Name))
        {
            byName[card.Name] = new OrderedBag<Battlecard>();
        }

        byName[card.Name].Add(card);
    }


    public void RemoveById(int id)
    {
        if (!byId.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        Battlecard card = byId[id];
        byId.Remove(id);
        byInsertion.Remove(card);
        byName[card.Name].Remove(card);
    }

    public bool Contains(Battlecard card)
    {
        return byId.ContainsKey(card.Id);
    }

    public void ChangeCardType(int id, CardType type)
    {
        if (!byId.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        byId[id].Type = type;
    }

    public Battlecard GetById(int id)
    {
        if (!byId.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        return byId[id];
    }

    public IEnumerable<Battlecard> FindFirstLeastSwag(int n)
    {
        if (n > Count)
        {
            throw new InvalidOperationException();
        }

        return byId.Values.OrderBy(x => x.Swag).ThenBy(x => x.Id).Take(n);
    }

    public IEnumerable<Battlecard> GetAllByNameAndSwag()
    {
        foreach (var name in this.byName)
        {
            yield return name.Value.GetFirst();
        }
    }

    public IEnumerable<Battlecard> GetAllInSwagRange(double lo, double hi)
    {
        return byId.Values.Where(x => x.Swag >= lo && x.Swag <= hi).OrderBy(x => x.Swag);
    }

    public IEnumerable<Battlecard> GetByCardType(CardType type)
    {
        var result = byId.Values.Where(x => x.Type == type).OrderBy(x => x);

        if (!result.Any())
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<Battlecard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
    {
        var result = byId.Values.Where(x => x.Type == type && x.Damage <= damage).OrderBy(x => x);

        if (!result.Any())
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<Battlecard> GetByNameAndSwagRange(string name, double lo, double hi)
    {
        var result = byId.Values.Where(x => x.Swag >= lo && x.Swag < hi && x.Name == name)
            .OrderByDescending(x => x.Swag).ThenBy(x => x.Id);

        if (!result.Any())
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<Battlecard> GetByNameOrderedBySwagDescending(string name)
    {
        var result = byId.Values.Where(x => x.Name == name).OrderByDescending(x => x.Swag).ThenBy(x => x.Id);

        if (!result.Any())
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerable<Battlecard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
    {
        var result = byId.Values.Where(x => x.Type == type && x.Damage > lo && x.Damage < hi).OrderBy(x => x);

        if (!result.Any())
        {
            throw new InvalidOperationException();
        }

        return result;
    }

    public IEnumerator<Battlecard> GetEnumerator()
    {
        foreach (var card in byInsertion)
        {
            yield return card;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
