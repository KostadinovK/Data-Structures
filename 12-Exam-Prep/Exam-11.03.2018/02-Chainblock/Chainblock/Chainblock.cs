using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Chainblock : IChainblock
{
    public int Count => throw new NotImplementedException();

    public void Add(Transaction tx)
    {
        throw new NotImplementedException();
    }

    public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
    {
        throw new NotImplementedException();
    }

    public bool Contains(Transaction tx)
    {
        throw new NotImplementedException();
    }

    public bool Contains(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetAllInAmountRange(double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetAllOrderedByAmountDescendingThenById()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {
        throw new NotImplementedException();
    }

    public Transaction GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetByTransactionStatus(TransactionStatus status)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Transaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<Transaction> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public void RemoveTransactionById(int id)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}

