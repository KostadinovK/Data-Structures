using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class PTest04
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
    public void Contains_10000_Elements()
    {

        List<Invoice> invoices = this.inputGenerator.GenerateInvoices(10000);



        foreach (Invoice inv in invoices)
        {
            this.agency.Create(inv);
        }
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        foreach (var inv in invoices)
        {
            this.agency.Contains(inv.SerialNumber);
        }
        stopwatch.Stop();

        long executionTimeInMillis = stopwatch.ElapsedMilliseconds;

        Assert.IsTrue(executionTimeInMillis <= 2);

    }
}