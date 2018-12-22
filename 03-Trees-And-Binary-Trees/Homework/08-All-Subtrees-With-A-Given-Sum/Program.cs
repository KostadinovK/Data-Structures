using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
	static Dictionary<int,Tree<int>> tree = new Dictionary<int, Tree<int>>();

	public static void Main()
	{
		ReadTree();
		Tree<int> root = tree.FirstOrDefault(x => x.Value.Parent == null).Value;
		int sum = int.Parse(Console.ReadLine());
		List<Tree<int>> subtrees = new List<Tree<int>>();

		List<Tree<int>> subtree = FindSubtreesWithSum(root,sum);
		Console.WriteLine(string.Join(" ",subtree.Select(x => x.Value)));
	}

	public static List<Tree<int>> FindSubtreesWithSum(Tree<int> node,int sum)
	{
		List<Tree<int>> currentSubtrees = new List<Tree<int>>();

		foreach (var child in node.Children)
		{
			foreach (var tree in FindSubtreesWithSum(child,sum))
			{
				currentSubtrees.Add(tree);
			}
		}

		if (FindSubtreeSum(node) == sum)
		{
			currentSubtrees.Add(node);
		}

		return currentSubtrees;
	}

	public static int FindSubtreeSum(Tree<int> node)
	{
		int subtreeSum = 0;
		foreach (var child in node.Children)
		{
			subtreeSum += FindSubtreeSum(child);
		}

		subtreeSum += node.Value;

		return subtreeSum;
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
