using System;
using System.Collections;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using System.Linq;

public class Instock : IProductStock
{
    private List<Product> products;
    private Dictionary<string, Product> byLabel;
    private Dictionary<int, HashSet<Product>> byQuantity;


    public Instock()
    {
        products = new List<Product>();
        byLabel = new Dictionary<string, Product>();
        byQuantity = new Dictionary<int, HashSet<Product>>();
    }

    public int Count => products.Count;

    public void Add(Product product)
    {
        products.Add(product);
        if (!byLabel.ContainsKey(product.Label))
        {
            byLabel.Add(product.Label, product);
            
        }

        if (!byQuantity.ContainsKey(product.Quantity))
        {
            byQuantity[product.Quantity] = new HashSet<Product>();
        }

        byQuantity[product.Quantity].Add(product);

    }

    public void ChangeQuantity(string product, int quantity)
    {
        if (!byLabel.ContainsKey(product))
        {
            throw new ArgumentException();
        }

        var p = byLabel[product];
        this.byQuantity[p.Quantity].Remove(p);

        if (!this.byQuantity.ContainsKey(quantity))
        {
            this.byQuantity[quantity] = new HashSet<Product>();
        }
        p.Quantity = quantity;

        this.byQuantity[quantity].Add(p);
    }

    public bool Contains(Product product)
    {
        return byLabel.ContainsKey(product.Label);
    }

    public Product Find(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException();
        }

        return products[index];
    }

    public IEnumerable<Product> FindAllByPrice(double price)
    {
        return products.Where(x => x.Price == price);
    }

    public IEnumerable<Product> FindAllByQuantity(int quantity)
    {
        if (!byQuantity.ContainsKey(quantity))
        {
            return new List<Product>();
        }

        return byQuantity[quantity];
    }

    public IEnumerable<Product> FindAllInRange(double lo, double hi)
    {
        return products.Where(x => x.Price > lo && x.Price <= hi).OrderByDescending(x => x.Price);
    }

    public Product FindByLabel(string label)
    {
        if (!byLabel.ContainsKey(label))
        {
            throw new ArgumentException();
        }

        return byLabel[label];
    }

    public IEnumerable<Product> FindFirstByAlphabeticalOrder(int count)
    {
        if (count < 0 || count > Count)
        {
            throw new ArgumentException();
        }

        return byLabel.Values.Take(count);
    }

    public IEnumerable<Product> FindFirstMostExpensiveProducts(int count)
    {
        if (count < 0 || count > Count)
        {
            throw new ArgumentException();
        }

        return products.OrderByDescending(x => x.Price).Take(count);
    }

    public IEnumerator<Product> GetEnumerator()
    {
        foreach (var product in products)
        {
            yield return product;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
