using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

class ShoppingCenter : IShoppingCenter
{
    private Dictionary<string, OrderedBag<Product>> byProducer;
    private Dictionary<string, OrderedBag<Product>> byName;
    private Dictionary<string, OrderedBag<Product>> byNameAndProducer;
    private OrderedDictionary<double, OrderedBag<Product>> byPrice;

    public ShoppingCenter()
    {
        byProducer = new Dictionary<string, OrderedBag<Product>>();
        byName = new Dictionary<string, OrderedBag<Product>>();
        byNameAndProducer = new Dictionary<string, OrderedBag<Product>>();
        byPrice = new OrderedDictionary<double, OrderedBag<Product>>();
    }

    public int Count {
        get { return byProducer.Count; }
    }
    public void AddProduct(Product product)
    {
        if (!byProducer.ContainsKey(product.Producer))
        {
            byProducer[product.Producer] = new OrderedBag<Product>();
        }

        byProducer[product.Producer].Add(product);

        if (!byName.ContainsKey(product.Name))
        {
            byName[product.Name] = new OrderedBag<Product>();
        }

        byName[product.Name].Add(product);

        if (!byNameAndProducer.ContainsKey(product.Name + product.Producer))
        {
            byNameAndProducer[product.Name + product.Producer] = new OrderedBag<Product>();
        }

        byNameAndProducer[product.Name + product.Producer].Add(product);

        if (!byPrice.ContainsKey(product.Price))
        {
            byPrice[product.Price] = new OrderedBag<Product>();
        }

        byPrice[product.Price].Add(product);
    }

    public int DeleteProducts(string producer)
    {
        if (!byProducer.ContainsKey(producer))
        {
            return 0;
        }

        List<Product> toDelete = byProducer[producer].ToList();
       
        foreach (var product in toDelete)
        {
            byName[product.Name].Remove(product);
            byProducer[product.Producer].Remove(product);
            byNameAndProducer[product.Name + product.Producer].Remove(product);
            byPrice[product.Price].Remove(product);
        }

        return toDelete.Count;
    }

    public int DeleteProducts(string name, string producer)
    {
        if (!byNameAndProducer.ContainsKey(name + producer))
        {
            return 0;
        }

        List<Product> toDelete = byNameAndProducer[name + producer].ToList();
        
        foreach (var product in toDelete)
        {
            byName[product.Name].Remove(product);
            byProducer[product.Producer].Remove(product);
            byNameAndProducer[product.Name + product.Producer].Remove(product);
            byPrice[product.Price].Remove(product);
        }

        return toDelete.Count;
    }

    public IEnumerable<Product> FindProductsByName(string name)
    {
        if (byName.ContainsKey(name))
        {
            return byName[name];
        }

        return new List<Product>();
    }

    public IEnumerable<Product> FindProductsByProducer(string producer)
    {
        if (byProducer.ContainsKey(producer))
        {
            return byProducer[producer];
        }

        return new List<Product>();
    }

    public IEnumerable<Product> FindProductsByPriceRange(double fromPrice, double toPrice)
    {
        OrderedBag<Product> res = new OrderedBag<Product>();

        foreach (var list in byPrice.Range(fromPrice, true, toPrice, true).Values)
        {
            foreach (var prod in list)
            {
                res.Add(prod);
            }
        }

        return res;
    }
}

