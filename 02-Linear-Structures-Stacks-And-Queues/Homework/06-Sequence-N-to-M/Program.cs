using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class Program
{
	public static void Main(string[] args)
	{
		Queue<int> res = new Queue<int>();

		Queue<Item> nums = new Queue<Item>();
		int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
		int start = input[0];
		int end = input[1];

		if (end < start)
		{
			return;
		}

		Item startItem = new Item(start);

		nums.Enqueue(startItem);
		while (true)
		{
			Item element = nums.Dequeue();

			if (element.Value == end)
			{
				Item currentItem = element;
				while (currentItem != null)
				{
					res.Enqueue(currentItem.Value);
					currentItem = currentItem.PrevItem;
				}

				break;
			}

			if (element.Value < end)
			{
				nums.Enqueue(new Item(element.Value + 1, element));
				nums.Enqueue(new Item(element.Value + 2, element));
				nums.Enqueue(new Item(element.Value * 2, element));
			}

			
		}

		Console.WriteLine(string.Join(" -> ",res.Reverse()));
	}
}

public class Item
{
	public int Value { get; private set; }
	public Item PrevItem { get; private set; }

	public Item(int value, Item prevItem = null)
	{
		Value = value;
		PrevItem = prevItem;
	}
}
