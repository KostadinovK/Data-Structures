using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
	public static void Main(string[] args)
	{
		LinkedStack<int> stack = new LinkedStack<int>();

		stack.Push(1);
		stack.Push(2);
		stack.Push(3);

		int[] arr = stack.ToArray();
		Console.WriteLine(string.Join(" ",arr));
	}
}
