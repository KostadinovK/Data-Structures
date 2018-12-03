using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
	public static void Main()
	{
		List<string> words = Console.ReadLine().Split().ToList();
		words = words.OrderBy(x => x).ToList();
		Console.WriteLine(string.Join(" ",words));
	}
}

