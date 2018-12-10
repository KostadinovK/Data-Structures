using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
	public static void Main(string[] args)
	{
		ArrayStack<int> stack = new ArrayStack<int>();
		stack.Push(1);
		stack.Push(2);
		stack.Push(3);
		stack.Push(4);
		stack.Push(5);
		stack.Push(6);
		Console.WriteLine(stack.Pop());
		Console.WriteLine(stack.Pop());
		int[] nums = stack.ToArray();
		Console.WriteLine(string.Join(", ",nums));
	}
}
