using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        Dictionary<char, int> occurrences = new Dictionary<char, int>();

        string text = Console.ReadLine();

        for (int i = 0; i < text.Length; i++)
        {
            if (!occurrences.ContainsKey(text[i]))
            {
                occurrences[text[i]] = 0;
            }

            occurrences[text[i]]++;
        }

        foreach (var occurrence in occurrences.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{occurrence.Key}: {occurrence.Value} time/s");
        }

    }
}
