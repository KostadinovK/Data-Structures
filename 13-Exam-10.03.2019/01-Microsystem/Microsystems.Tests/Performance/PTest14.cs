using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

public class PTest14
{
    protected IMicrosystem microsystems;
    protected InputGenerator inputGenerator;

    protected class InputGenerator
    {

        private static Random RANDOM = new Random();
        private double[] SCREEN_SIZE = { 15.6, 14, 13.2, 16, 13.3 };
        private static string[] COLORS = { "white", "gray", "black", "red", "pink", "orange", "yellow", "green", "magenta", "cyan", "blue" };

        public List<Computer> GenerateComputers(int count)
        {
            List<Computer> computers = new List<Computer>();
            Array values = Enum.GetValues(typeof(Brand));
            for (int i = 1; i <= count; i++)
            {
                String color = COLORS[Math.Abs(RANDOM.Next()) % COLORS.Length];
                Brand brand = (Brand)values.GetValue(RANDOM.Next(values.Length));
                double price = 1000D + (5000D - 1000D) * RANDOM.NextDouble();
                double screenSize = SCREEN_SIZE[Math.Abs(RANDOM.Next()) % SCREEN_SIZE.Length];
                Computer computer = new Computer(i, brand, price, screenSize, color);
                computers.Add(computer);
            }
            return computers.OrderBy(x => Guid.NewGuid()).ToList();

        }
        public KeyValuePair<TKey, int> MostOccur<TKey>(IList<Computer> computers, Func<Computer, TKey> selector)
        {
            return computers.GroupBy(selector).ToDictionary(k => k.Key, v => v.Count()).OrderByDescending(x => x.Key).FirstOrDefault();
        }


    }

    [SetUp]
    public void Init()
    {
        this.microsystems = new Microsystems();
        this.inputGenerator = new InputGenerator();
    }
    [TestCase]
    public void GetAllFromBrand_With_100_000_Entities()
    {

        List<Computer> computers = this.inputGenerator.GenerateComputers(100000);
        Brand brand = inputGenerator.MostOccur(computers, x => x.Brand).Key;

        foreach (var comp in computers)
        {
            microsystems.CreateComputer(comp);
        }
        var watch = new Stopwatch();
        watch.Start();

        microsystems.GetAllFromBrand(brand);


        watch.Stop();

        long elapsedTime = watch.ElapsedMilliseconds;

        //throw new ArgumentException("time: " + elapsedTime);

          Assert.IsTrue(elapsedTime <= 55);


    }
}
