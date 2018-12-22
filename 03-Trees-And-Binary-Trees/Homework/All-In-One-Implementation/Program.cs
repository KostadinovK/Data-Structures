using System;
using System.Collections.Generic;
using System.Linq;


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

	public Tree<T> GetRoot()
	{
		if (this.Parent == null)
		{
			return this;
		}

		return this.Parent.GetRoot();
	}

	public void PrintTree(int indent = 0)
	{
		PrintTree(this,indent);
	}

	private void PrintTree(Tree<T> root,int indent)
	{
		Console.WriteLine($"{new string(' ',indent)}{root.Value}");
		foreach (var child in root.Children)
		{
			PrintTree(child,indent+2);
		}
	}

	public List<Tree<T>> GetAllLeafs()
	{
		List<Tree<T>> result = new List<Tree<T>>();

		Queue<Tree<T>> nodes = new Queue<Tree<T>>();
		nodes.Enqueue(this);

		Tree<T> current = null;
		while (nodes.Count > 0)
		{
			current = nodes.Dequeue();
			if (current.Children.Count == 0)
			{
				result.Add(current);
			}

			foreach (var child in current.Children)
			{
				nodes.Enqueue(child);
			}
		}

		return result;
	}

	public List<Tree<T>> GetAllMiddleNodes()
	{
		List<Tree<T>> middleNodes = new List<Tree<T>>();

		Queue<Tree<T>> nodes = new Queue<Tree<T>>();
		nodes.Enqueue(this);
		Tree<T> current = null;

		while (nodes.Count > 0)
		{
			current = nodes.Dequeue();
			if (current.Parent != null && current.Children.Count > 0)
			{
				middleNodes.Add(current);
			}

			foreach (var child in current.Children)
			{
				nodes.Enqueue(child);
			}
		}

		return middleNodes;
	}

	public Tree<T> GetDeepestNode()
	{
		Tree<T> res = this;

		Queue<Tree<T>> nodes = new Queue<Tree<T>>();
		nodes.Enqueue(res);

		while (nodes.Count > 0)
		{
			res = nodes.Dequeue();
			if (res.Children.Count == 0)
			{
				return res;
			}

			nodes.Enqueue(res.Children[0]);
		}

		return res;
	}

	public void PrintLongestPath()
	{
		List<T> path = GetLongestPath(this);
		Console.WriteLine(string.Join(" ",path));
	}

	private List<T> GetLongestPath(Tree<T> node)
	{
		List<T> result = new List<T>();
		List<T> path;

		foreach (var child in node.Children)
		{
			 path = GetLongestPath(child);

			if (path.Count > result.Count)
			{
				result = path;
			}

		}


		result.Insert(0,node.Value);
		return result;
	}

	public void PrintPathsWithGivenSum(int targetSum)
	{
		PrintPathsWithGivenSum(this,0,targetSum);
	}

	private void PrintPathsWithGivenSum(Tree<T> node, int sum, int targetSum)
	{
		sum += Convert.ToInt32(node.Value);
		
		if (sum == targetSum)
		{
			Stack<T> path = new Stack<T>();
			Tree<T> current = node;
			path.Push(current.Value);
			while (current.Parent != null)
			{
				current = current.Parent;
				path.Push(current.Value);
			}

			Console.WriteLine(string.Join(" ",path));
		}

		foreach (var child in node.Children)
		{
			PrintPathsWithGivenSum(child,sum,targetSum);
		}

	}

	public void PrintSubtreesWithGivenSum(int sum)
	{
		List<Tree<T>> subtrees = new List<Tree<T>>();

		PrintSubtreesWithGivenSum(this,sum,0,subtrees);
		Console.WriteLine("Subtrees of sum " + sum + ":");
		foreach (var subtree in subtrees)
		{
			PrintTreePreOrder(subtree);
			Console.WriteLine();
		}
	}

	private int PrintSubtreesWithGivenSum(Tree<T> node, int targetSum, int sum,List<Tree<T>> subtrees)
	{
		sum = Convert.ToInt32(node.Value);

		foreach (var child in node.Children)
		{
			sum += PrintSubtreesWithGivenSum(child, targetSum, sum, subtrees);
		}

		if (sum == targetSum)
		{
			subtrees.Add(node);
		}

		return sum;
	}
	private void PrintTreePreOrder(Tree<T> node)
	{
		Console.Write(node.Value + " ");

		foreach (var child in node.Children)
		{
			PrintTreePreOrder(child);
		}
	}

	
}



public class Program
{

	static Dictionary<int,Tree<int>> tree = new Dictionary<int, Tree<int>>();
	public static void Main()
	{
		ReadTree();
		Tree<int> root = tree.FirstOrDefault(x => x.Value.Parent == null).Value;

		int sum = int.Parse(Console.ReadLine());
		root.PrintSubtreesWithGivenSum(sum);
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
				tree.Add(childValue,new Tree<int>(childValue));
			}

			Tree<int> parent = tree[parentValue];
			Tree<int> child = tree[childValue];

			parent.Children.Add(child);
			child.Parent = parent;
		}
	}
}
