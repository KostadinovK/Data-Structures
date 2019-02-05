
using System;

public class Product : IComparable<Product>
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Producer { get; set; }

    public Product(string name, double price, string producer)
    {
        Name = name;
        Price = price;
        Producer = producer;
    }

    public int CompareTo(Product other)
    {
        int compare = this.Name.CompareTo(other.Name);
        if (compare == 0)
        {
            compare = this.Producer.CompareTo(other.Producer);
            if (compare == 0)
            {
                compare = this.Price.CompareTo(other.Price);
            }
        }

        return compare;
    }

    public override string ToString()
    {
        return "{" + $"{Name};{Producer};{Price:f2}" + "}";
    }
}
