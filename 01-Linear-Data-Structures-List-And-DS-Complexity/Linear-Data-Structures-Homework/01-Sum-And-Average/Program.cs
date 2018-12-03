using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
	public static void Main()
	{
		List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
		Console.WriteLine($"Sum={nums.Sum()}; Average={nums.Average():f2}");
	}
}
