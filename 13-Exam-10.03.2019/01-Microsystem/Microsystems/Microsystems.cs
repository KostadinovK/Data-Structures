using System;
using System.Collections.Generic;
using System.Linq;

public class Microsystems : IMicrosystem
{

    private Dictionary<int, Computer> byNumber;

    public Microsystems()
    {
        byNumber = new Dictionary<int, Computer>();
    }

    public bool Contains(int number)
    {
        return byNumber.ContainsKey(number);
    }

    public int Count()
    {
        return byNumber.Count;
    }

    public void CreateComputer(Computer computer)
    {
        if (byNumber.ContainsKey(computer.Number))
        {
            throw new ArgumentException();
        }

        byNumber.Add(computer.Number, computer);
    }

    public IEnumerable<Computer> GetAllFromBrand(Brand brand)
    {
        return byNumber.Values.Where(x => x.Brand == brand).OrderByDescending(x => x.Price);
    }

    public IEnumerable<Computer> GetAllWithColor(string color)
    {
        return byNumber.Values.Where(x => x.Color == color).OrderByDescending(x => x.Price);
    }

    public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
    {
        return byNumber.Values.Where(x => x.ScreenSize == screenSize).OrderByDescending(x => x.Number);
    }

    public Computer GetComputer(int number)
    {
        if (!byNumber.ContainsKey(number))
        {
            throw new ArgumentException();
        }

        return byNumber[number];
    }

    public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
    {
        return byNumber.Values.Where(x => x.Price >= minPrice && x.Price <= maxPrice).OrderByDescending(x => x.Price);
    }

    public void Remove(int number)
    {
        if (!byNumber.ContainsKey(number))
        {
            throw new ArgumentException();
        }

        byNumber.Remove(number);
    }

    public void RemoveWithBrand(Brand brand)
    {
        var toRemove = byNumber.Values.Where(x => x.Brand == brand).ToList();

        if (!toRemove.Any())
        {
            throw new ArgumentException();
        }

        toRemove.ForEach(x => byNumber.Remove(x.Number));
    }

    public void UpgradeRam(int ram, int number)
    {
        if (!byNumber.ContainsKey(number))
        {
            throw new ArgumentException();
        }

        if (ram > byNumber[number].RAM)
        {
            byNumber[number].RAM = ram;
        }
    }
}
