using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
	static Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();
	public static void Main()
	{
		ReadTree();
		List<Tree<int>> middleNodes = tree.Values.Where(x => x.Parent != null && x.Children.Count > 0).OrderBy(x => x.Value).ToList();
		Console.WriteLine("Middle nodes: " + string.Join(" ",middleNodes.Select(x => x.Value)));
	}

	private static void ReadTree()
	{
		int nodesCount = int.Parse(Console.ReadLine());

		for (int i = 1; i < nodesCount;i++)
		{
			int[] nodesValues = Console.ReadLine().Split().Select(int.Parse).ToArray();

			int parentValue = nodesValues[0];
			int childValue = nodesValues[1];

			if (!tree.ContainsKey(parentValue))
			{
				tree.Add(parentValue,new Tree<int>(parentValue));
			}

			if (!tree.ContainsKey(childValue))
			{
				tree.Add(childValue,new Tree<int>(childValue));
			}

			Tree<int> parent = tree[parentValue];
			Tree<int> child = tree[childValue];

			parent.Children.Add(child);
			child.Parent = parent;

		}
	}
}

public class Tree<T>
{
	public T Value { get; set; }
	public Tree<T> Parent { get; set; }
	public List<Tree<T>> Children { get; set; }

	public Tree(T value, params Tree<T>[] children)
	{
		this.Value = value;
		this.Children = new List<Tree<T>>(children);
	}
}
