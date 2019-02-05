
using System.Collections.Generic;

public interface IShoppingCenter
{
    int Count { get; }
    void AddProduct(Product product);
    int DeleteProducts(string producer);
    int DeleteProducts(string name, string producer);
    IEnumerable<Product> FindProductsByName(string name);
    IEnumerable<Product> FindProductsByProducer(string producer);
    IEnumerable<Product> FindProductsByPriceRange(double fromPrice, double toPrice);
}

