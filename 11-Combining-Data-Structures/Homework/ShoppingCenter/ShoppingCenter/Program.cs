
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        ShoppingCenter center = new ShoppingCenter();

        int commandsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            string line = Console.ReadLine();
            string command = line.Split(' ').ToArray()[0];
            line = line.Substring(line.IndexOf(' ') + 1);

            switch (command)
            {
                case "AddProduct":
                    string[] tokens = line.Split(';').ToArray();
                    Product p = new Product(tokens[0], double.Parse(tokens[1]), tokens[2]);
                    center.AddProduct(p);
                    Console.WriteLine("Product added");
                    break;

                case "FindProductsByName":
                    List<Product> foundByName = center.FindProductsByName(line).ToList();
                    if (foundByName.Count == 0)
                    {
                        Console.WriteLine("No products found");
                    }
                    else
                    {
                        Console.WriteLine(string.Join("\n", foundByName));
                    }

                    break;

                case "FindProductsByProducer":

                    List<Product> foundByProducer = center.FindProductsByProducer(line).ToList();
                    if (foundByProducer.Count == 0)
                    {
                        Console.WriteLine("No products found");
                    }
                    else
                    {
                        Console.WriteLine(string.Join("\n", foundByProducer));
                    }
                    break;

                case "FindProductsByPriceRange":

                    string[] prices = line.Split(';').ToArray();
                    double price1 = double.Parse(prices[0]);
                    double price2 = double.Parse(prices[1]);
                    List<Product> found = center.FindProductsByPriceRange(price1, price2).ToList();
                    if (found.Count == 0)
                    {
                        Console.WriteLine("No products found");
                    }
                    else
                    {
                        Console.WriteLine(string.Join("\n", found));
                    }

                    break;

                case "DeleteProducts":

                    if (line.Contains(';'))
                    {
                        string[] args = line.Split(';').ToArray();
                        int deletedProducts = center.DeleteProducts(args[0], args[1]);
                        if (deletedProducts == 0)
                        {
                            Console.WriteLine("No products found");
                        }
                        else
                        {
                            Console.WriteLine($"{deletedProducts} products deleted");
                        }
                        
                    }
                    else
                    {
                        int deletedProducts = center.DeleteProducts(line);
                        if (deletedProducts == 0)
                        {
                            Console.WriteLine("No products found");
                        }
                        else
                        {
                            Console.WriteLine($"{deletedProducts} products deleted");
                        }
                    }

                    break;

            }

        }
    }
}

