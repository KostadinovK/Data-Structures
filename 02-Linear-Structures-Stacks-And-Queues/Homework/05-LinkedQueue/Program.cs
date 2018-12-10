using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
	public static void Main(string[] args)
	{
		LinkedQueue<int> queue = new LinkedQueue<int>();

		queue.Enqueue(1);
		queue.Enqueue(2);
		queue.Enqueue(3);
		queue.Enqueue(4);
		int toRemove = queue.Dequeue();
		Console.WriteLine("---" + toRemove + "---");
		int[] arr = queue.ToArray();
		Console.WriteLine(string.Join(" ",arr));
	}
}
