using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        Dictionary<string,string> phonebook = new Dictionary<string, string>();

        string line = Console.ReadLine();

        while (line != "search")
        {
            string[] tokens = line.Split('-').ToArray();

            if (!phonebook.ContainsKey(tokens[0]))
            {
                phonebook[tokens[0]] = tokens[1];
            }

            line = Console.ReadLine();
        }

        line = Console.ReadLine();

        while (line != "end")
        {
            if (phonebook.ContainsKey(line))
            {
                Console.WriteLine($"{line} -> {phonebook[line]}");
            }
            else
            {
                Console.WriteLine($"Contact {line} does not exist.");
            }

            line = Console.ReadLine();
        }
    }
}
