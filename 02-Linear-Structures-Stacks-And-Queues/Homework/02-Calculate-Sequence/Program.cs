using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

public class Program
{
	public static void Main(string[] args)
	{
		Queue<int> nums = new Queue<int>();
		Queue<int> res = new Queue<int>();
		int n = int.Parse(Console.ReadLine());
		nums.Enqueue(n);
		while (nums.Count < 100)
		{
			int last = nums.Peek();
			
			nums.Enqueue(last + 1);
			nums.Enqueue(2 * last + 1);
			nums.Enqueue(last + 2);
			int delete = nums.Dequeue();
			res.Enqueue(delete);
		}

		Console.WriteLine(string.Join(", ",res));
	}

}
