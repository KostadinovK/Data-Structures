using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Board : IBoard
{

    private Dictionary<string, Card> deck;

    public Board()
    {
        deck = new Dictionary<string, Card>();
    }

    public bool Contains(string name)
    {
        return deck.ContainsKey(name);
    }

    public int Count()
    {
        return deck.Count;
    }

    public void Draw(Card card)
    {
        if (deck.ContainsKey(card.Name))
        {
            throw new ArgumentException();
        }

        deck.Add(card.Name, card);
    }

    public IEnumerable<Card> GetBestInRange(int start, int end)
    {
        return deck.Values.Where(x => x.Score >= start && x.Score <= end).OrderByDescending(x => x.Level);
    }

    public void Heal(int health)
    {
        int minHealth = deck.Values.Select(x => x.Health).Min();

        Card withLowestHealth = deck.Values.Where(x => x.Health == minHealth).ToArray()[0];

        withLowestHealth.Health += health;
    }

    public IEnumerable<Card> ListCardsByPrefix(string prefix)
    {
        return deck.Values.Where(x => x.Name.StartsWith(prefix)).OrderBy(x => new string(x.Name.Reverse().ToArray())).ThenBy(x => x.Level);
    }


    public void Play(string attackerCardName, string attackedCardName)
    {
        if (!deck.ContainsKey(attackerCardName) || !deck.ContainsKey(attackedCardName))
        {
            throw new ArgumentException();
        }

        Card attacker = deck[attackerCardName];
        Card attacked = deck[attackedCardName];

        if (attacker.Level != attacked.Level)
        {
            throw new ArgumentException();
        }

        if (attacker.Available && attacked.Available)
        {
            attacked.Health -= attacker.Damage;

            if (attacked.Health <= 0)
            {
                attacker.Score += attacked.Level;
                attacked.Available = false;
            }
        }
    }

    public void Remove(string name)
    {
        if (!deck.ContainsKey(name))
        {
            throw new ArgumentException();
        }

        deck.Remove(name);
    }

    public void RemoveDeath()
    {
        var toRemove = deck.Values.Where(x => x.Health <= 0).ToList();

        if (toRemove.Any())
        {
            toRemove.ForEach(x => deck.Remove(x.Name));
        }
    }

    public IEnumerable<Card> SearchByLevel(int level)
    {
        return deck.Values.Where(x => x.Level == level).OrderByDescending(x => x.Score);
    }
}