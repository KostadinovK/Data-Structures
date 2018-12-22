using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

public class Program
{
	static Dictionary<int,Tree<int>> tree = new Dictionary<int, Tree<int>>();

	public static void Main()
	{
		ReadTree();
		Tree<int> root = tree.FirstOrDefault(x => x.Value.Parent == null).Value;
		Tree<int> deepestNode = GetDeepestNode(root);
		Console.WriteLine("Deepest node: " + deepestNode.Value);
	}


	private static void ReadTree()
	{
		int nodesCount = int.Parse(Console.ReadLine());

		for (int i = 1;i < nodesCount;i++)
		{
			int[] nodes = Console.ReadLine().Split().Select(int.Parse).ToArray();

			int parentValue = nodes[0];
			int childValue = nodes[1];

			if (!tree.ContainsKey(parentValue))
			{
				tree.Add(parentValue,new Tree<int>(parentValue));
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

	public static Tree<int> GetDeepestNode(Tree<int> root)
	{
		Queue<Tree<int>> nodes = new Queue<Tree<int>>();
		nodes.Enqueue(root);
		Tree<int> current = null;
		while (nodes.Count > 0)
		{
			current = nodes.Dequeue();
			for (int i = current.Children.Count-1;i >= 0;i--)
			{
				nodes.Enqueue(current.Children[i]);
			}

		}

		return current;
	}
}
