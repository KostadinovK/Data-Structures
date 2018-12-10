using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
	public static void Main(string[] args)
	{
		Stack<int> stack = new Stack<int>();
		List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

		for (int i = 0;i < nums.Count;i++)
		{
			stack.Push(nums[i]);
		}

		while (stack.Count > 0)
		{
			Console.Write(stack.Pop() + " ");
		}
	}
}
