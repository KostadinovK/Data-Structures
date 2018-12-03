using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public class Program
{
	public static void Main()
	{
		ReversedList<int> nums = new ReversedList<int>();

		nums.Add(1);
		nums.Add(2);
		nums.Add(3);
		nums.Add(4);
		nums.Add(5);
		Console.WriteLine(nums[3]);
		Console.WriteLine(nums.Count);
		Console.WriteLine(nums.Capacity);

		nums.RemoveAt(4);
		foreach (var num in nums)
		{
			Console.WriteLine(num);
		}

	}
}
