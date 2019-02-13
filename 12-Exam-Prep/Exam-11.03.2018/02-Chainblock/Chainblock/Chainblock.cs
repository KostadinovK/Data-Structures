using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Wintellect.PowerCollections;

public class Chainblock : IChainblock
{

    private Dictionary<int, Transaction> byId;
    private Dictionary<TransactionStatus, HashSet<Transaction>> byStatus;
    public Chainblock()
    {
        byId = new Dictionary<int, Transaction>();
        byStatus = new Dictionary<TransactionStatus, HashSet<Transaction>>();
    }

    public int Count => byId.Count;

    public void Add(Transaction tx)
    {
        byId.Add(tx.Id, tx);

        if (!byStatus.ContainsKey(tx.Status))
        {
            byStatus[tx.Status] = new HashSet<Transaction>();
        }

        byStatus[tx.Status].Add(tx);
    }

    public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
    {
        if (!byId.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        byId[id].Status = newStatus;
    }

    public bool Contains(Transaction tx)
    {
        return byId.ContainsKey(tx.Id);
    }

    public bool Contains(int id)
    {
        return byId.ContainsKey(id);
    }

    public void RemoveTransactionById(int id)
    {
        if (!byId.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        Transaction tx = byId[id];

        byStatus[tx.Status].Remove(tx);
        byId.Remove(id);
    }

    public Transaction GetById(int id)
    {
        if (!byId.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }

        return byId[id];
    }

    public IEnumerable<Transaction> GetAllInAmountRange(double lo, double hi)
    {
        return byId.Values.Where(x => x.Amount >= lo && x.Amount <= hi);
    }

    public IEnumerable<Transaction> GetAllOrderedByAmountDescendingThenById()
    {
        return byId.Values.OrderBy(x => x);
    }

    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        if (!byStatus.ContainsKey(status))
        {
            throw new InvalidOperationException();
        }

        var res = byStatus[status].OrderByDescending(x => x.Amount).Select(x => x.To);

        if (!res.Any())
        {
            throw new InvalidOperationException();
        }

        return res;
    }

    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {
        if (!byStatus.ContainsKey(status))
        {
            throw new InvalidOperationException();
        }

        var res = byStatus[status].OrderByDescending(x => x.Amount).Select(x => x.From);

        if (!res.Any())
        {
            throw new InvalidOperationException();
        }

        return res;
    }

    public IEnumerable<Transaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        var res = byId.Values.Where(x => x.To == receiver && x.Amount >= lo && x.Amount < hi).OrderBy(x => x);

        if (!res.Any())
        {
            throw new InvalidOperationException();
        }

        return res;
    }

    public IEnumerable<Transaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        var res = byId.Values.Where(x => x.To == receiver).OrderBy(x => x);

        if (!res.Any())
        {
            throw new InvalidOperationException();
        }

        return res;
    }

    public IEnumerable<Transaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        var res = byId.Values.Where(x => x.From == sender && x.Amount > amount).OrderByDescending(x => x.Amount);

        if (!res.Any())
        {
            throw new InvalidOperationException();
        }

        return res;
    }

    public IEnumerable<Transaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        var res = byId.Values.Where(x => x.From == sender).OrderByDescending(x => x.Amount).ThenByDescending(x => x.Id);

        if (!res.Any())
        {
            throw new InvalidOperationException();
        }

        return res;
    }

    public IEnumerable<Transaction> GetByTransactionStatus(TransactionStatus status)
    {
        if (!byStatus.ContainsKey(status))
        {
            throw new InvalidOperationException();
        }

        return byStatus[status].OrderByDescending(x => x.Amount).ThenByDescending(x => x.Id);
    }

    public IEnumerable<Transaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        if (!byStatus.ContainsKey(status))
        {
            return new List<Transaction>();
        }

        return byStatus[status].Where(x => x.Amount <= amount).OrderByDescending(x => x.Amount);
    }

    public IEnumerator<Transaction> GetEnumerator()
    {
        foreach (var kvp in byId)
        {
            yield return kvp.Value;
        }
    }

    

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

