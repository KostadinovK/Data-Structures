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

		Dictionary<int,int> numberOccurrences = new Dictionary<int, int>();

		for (int i = 0;i < nums.Count;i++)
		{
			if (!numberOccurrences.ContainsKey(nums[i]))
			{
				numberOccurrences.Add(nums[i],1);
			}
			else
			{
				numberOccurrences[nums[i]]++;
			}
		}

		foreach (var kvp in numberOccurrences.OrderBy(x => x.Key))
		{
			Console.WriteLine(kvp.Key + " -> " + kvp.Value + " times");
		}
	}
}
