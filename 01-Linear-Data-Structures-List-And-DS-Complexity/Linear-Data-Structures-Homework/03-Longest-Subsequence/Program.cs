using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class Program
{
	public static void Main()
	{
		List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

		List<int> result = new List<int>();

		int maxCount = -1;
		int number = 0;
		for (int i = 0;i < nums.Count;i++)
		{
			int count = 1;
			for (int j = i+1;j < nums.Count;j++) {
				if (nums[i] == nums[j])
				{
					count++;
				}
				else
				{
					break;
				}
			}

			if (maxCount < count)
			{
				maxCount = count;
				number = nums[i];
			}
		}

		for (int i = 0;i < maxCount;i++)
		{
			result.Add(number);
		}

		Console.WriteLine(string.Join(" ",result));
	}
}
