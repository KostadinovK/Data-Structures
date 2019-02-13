using System;

public class Transaction : IComparable<Transaction>
{
    public int Id { get; set; }
    public TransactionStatus Status { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public double Amount { get; set; }

    public Transaction(int id, TransactionStatus st, string from, string to, double amount)
    {
        this.Id = id;
        this.Status = st;
        this.From = from;
        this.To = to;
        this.Amount = amount;
    }

    public int CompareTo(Transaction other)
    {
        int compare = other.Amount.CompareTo(this.Amount);

        if (compare == 0)
        {
            compare = this.Id.CompareTo(other.Id);
        }

        return compare;
    }
}