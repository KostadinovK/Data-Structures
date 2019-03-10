using System;
using System.Collections.Generic;
using System.Linq;

public class Agency : IAgency
{
    private Dictionary<string, Invoice> byNumber;

    public Agency()
    {
        byNumber = new Dictionary<string, Invoice>();
    }

    public bool Contains(string number)
    {
        return byNumber.ContainsKey(number);
    }

    public int Count()
    {
        return byNumber.Count;
    }

    public void Create(Invoice invoice)
    {
        if (byNumber.ContainsKey(invoice.SerialNumber))
        {
            throw new ArgumentException();
        }

        byNumber.Add(invoice.SerialNumber, invoice);
    }

    public void ExtendDeadline(DateTime dueDate, int days)
    {
        var toExtend = byNumber.Values.Where(x => x.DueDate == dueDate).ToList();
        
        if (!toExtend.Any())
        {
            throw new ArgumentException();
        }

        foreach (var invoice in toExtend)
        {
            byNumber[invoice.SerialNumber].DueDate = invoice.DueDate.AddDays(5);
        }
    }

    public IEnumerable<Invoice> GetAllByCompany(string company)
    {
        return byNumber.Values.Where(x => x.CompanyName == company).OrderByDescending(x => x.SerialNumber);
    }

    public IEnumerable<Invoice> GetAllFromDepartment(Department department)
    {
        return byNumber.Values.Where(x => x.Department == department).OrderByDescending(x => x.Subtotal)
            .ThenBy(x => x.IssueDate);
    }

    public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
    {
        return byNumber.Values.Where(x => x.IssueDate >= start && x.IssueDate <= end).OrderBy(x => x.IssueDate)
            .ThenBy(x => x.DueDate);
    }

    public void PayInvoice(DateTime due)
    {
        var toPay = byNumber.Values.Where(x => x.DueDate == due).ToList();

        if (!toPay.Any())
        {
            throw new ArgumentException();
        }

        toPay.ForEach(x => x.Subtotal = 0);
    }

    public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
    {
        var result = byNumber.Values.Where(x => x.SerialNumber.Contains(serialNumber)).ToList();

        if (!result.Any())
        {
            throw new ArgumentException();
        }

        return result;
    }

    public void ThrowInvoice(string number)
    {
        if (!byNumber.ContainsKey(number))
        {
            throw new ArgumentException();
        }

        byNumber.Remove(number);
    }

    public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
    {
        var toThrow = byNumber.Values.Where(x => x.DueDate > start && x.DueDate < end).ToList();

        if (!toThrow.Any())
        {
            throw new ArgumentException();
        }

        toThrow.ForEach(x => byNumber.Remove(x.SerialNumber));

        return toThrow;
    }

    public void ThrowPayed()
    {
        var toRemove = byNumber.Values.Where(x => x.Subtotal == 0).ToList();

        toRemove.ForEach(x => byNumber.Remove(x.SerialNumber));
    }
}
