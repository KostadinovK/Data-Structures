using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

public class PTest08
{
    protected IAgency agency;
    protected InputGenerator inputGenerator;

    public class InputGenerator
    {

        private static Random RANDOM = new Random();
        private static string[] COMPANIES = { "HRS", "SoftUni", "Expedia", "SBTech", "Codexio", "VMWare", "Musala", "Chaos Group", "PaySafe", "Motion", "Locktrip" };

        public List<Invoice> GenerateInvoices(int count)
        {
            List<Invoice> generated = new List<Invoice>();
            for (int i = 0; i < count; i++)
            {
                string uuid = Guid.NewGuid().ToString();
                string company = COMPANIES[Math.Abs(RANDOM.Next()) % COMPANIES.Length];
                double subTotal = RANDOM.NextDouble() * Math.Abs(RANDOM.Next());
                var department = (Department)Enum.GetValues(typeof(Department)).GetValue(Math.Abs(RANDOM.Next()) % Enum.GetValues(typeof(Department)).Length);

                DateTime firstDate = GetRandomDate(new DateTime(2010, 1, 1), new DateTime(2015, 1, 1));
                DateTime secondDate = this.GetRandomDate(new DateTime(2018, 1, 1), new DateTime(2020, 1, 1));
                generated.Add(new Invoice(uuid, company, subTotal, department, firstDate, secondDate));

            }
            return generated;
        }
        public KeyValuePair<TKey, int> MostOccur<TKey>(IList<Invoice> invoices, Func<Invoice, TKey> selector)
        {
            return invoices.GroupBy(selector).ToDictionary(k => k.Key, v => v.Count()).OrderByDescending(x => x.Key).FirstOrDefault();
        }

        DateTime GetRandomDate(DateTime dtStart, DateTime dtEnd)
        {
            int cdayRange = (dtEnd - dtStart).Days;

            return dtStart.AddDays(RANDOM.NextDouble() * cdayRange).Date;
        }

    }

    [SetUp]
    public void Init()
    {
        this.agency = new Agency();
        this.inputGenerator = new InputGenerator();
    }

    [TestCase]
    public void PayInvoice_100000_Elements()
    {
        Stopwatch st = new Stopwatch();

        List<Invoice> invoices = this.inputGenerator.GenerateInvoices(100000);
        

        foreach (var inv in invoices)
        {
            agency.Create(inv);
        }
       

        var mostOccurrences = this.inputGenerator.MostOccur(invoices, x => x.DueDate);

        var stopwach = new Stopwatch();
        stopwach.Start();
        this.agency.PayInvoice(mostOccurrences.Key);
        stopwach.Stop();

        var elapsed = stopwach.ElapsedMilliseconds;

        Assert.IsTrue(elapsed <= 3);
    }

}
