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

		List<int> result = new List<int>();

		for (int i = 0; i < nums.Count; i++)
		{
			int count = 0;
			for (int j = 0;j < nums.Count;j++)
			{
				if (nums[i] == nums[j])
				{
					count++;
				}
			}

			if (count % 2 == 0)
			{
				result.Add(nums[i]);
			}
		}

		Console.WriteLine(string.Join(" ",result));
	}
}