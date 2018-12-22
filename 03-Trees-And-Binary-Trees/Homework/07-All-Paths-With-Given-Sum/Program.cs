using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class Program
{
	static Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();
	public static void Main()
	{
		ReadTree();
		int sum = int.Parse(Console.ReadLine());
		Tree<int> root = tree.FirstOrDefault(x => x.Value.Parent == null).Value;
		List<int> path = new List<int>();
		Console.WriteLine("Paths of sum " + sum + ":");
		PrintAllPathsWithGivenSum(root,sum,path);
	}

	private static void PrintAllPathsWithGivenSum(Tree<int> node, int sum, List<int> path)
	{
		path.Add(node.Value);
		if (node.Children.Count == 0)
		{
			if (path.Sum() == sum)
			{
				Console.WriteLine(string.Join(" ",path));
			}

			path.Remove(node.Value);
			return;
		}

		foreach (var child in node.Children)
		{
			PrintAllPathsWithGivenSum(child,sum,path);
		}

		path.Remove(node.Value);

	}

	private static void ReadTree()
	{
		int nodesCount = int.Parse(Console.ReadLine());

		for (int i = 1; i < nodesCount; i++)
		{
			int[] nodes = Console.ReadLine().Split().Select(int.Parse).ToArray();

			int parentValue = nodes[0];
			int childValue = nodes[1];

			if (!tree.ContainsKey(parentValue))
			{
				tree.Add(parentValue, new Tree<int>(parentValue));
			}

			if (!tree.ContainsKey(childValue))
			{
				tree.Add(childValue, new Tree<int>(childValue));
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
		this.Children = new List<Tree<T>>();
	}
}
