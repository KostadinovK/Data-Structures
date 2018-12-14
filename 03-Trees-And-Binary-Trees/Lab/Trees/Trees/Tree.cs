using System;
using System.Collections.Generic;

public class Tree<T>
{
	public T Value { get; private set; }
	public List<Tree<T>> Children { get; private set; }

	public Tree(T value, params Tree<T>[] children)
	{
		this.Value = value;
		this.Children = new List<Tree<T>>(children);
	}

    public void Print(int indent = 0)
    {
		Print(this,0);
    }

	private void Print(Tree<T> tree, int indent)
	{
		Console.WriteLine($"{new string(' ',indent)}{tree.Value}");
		for (int i = 0;i < tree.Children.Count;i++) 
		{
			Print(tree.Children[i],indent+2);
		}
	}

	public void Each(Action<T> action)
    {
        Each(this,action);
    }

	private void Each(Tree<T> tree, Action<T> action)
	{
		action(tree.Value);
		foreach (Tree<T> child in tree.Children)
		{
			Each(child,action);
		}
	}

	public IEnumerable<T> OrderDFS()
    {
        List<T> result = new List<T>();
	    OrderDFS(this,result);

	    return result;
    }

	private void OrderDFS(Tree<T> tree, List<T> result)
	{
		if (tree == null)
		{
			return;
		}

		foreach (Tree<T> child in tree.Children)
		{
			OrderDFS(child, result);
		}

		result.Add(tree.Value);
	}

	public IEnumerable<T> OrderBFS()
    {
        Queue<Tree<T>> trees = new Queue<Tree<T>>();
		List<T> result = new List<T>();
		trees.Enqueue(this);
	    while (trees.Count > 0)
	    {
		    Tree<T> currentTree = trees.Dequeue();
			result.Add(currentTree.Value);

		    foreach (Tree<T> child in currentTree.Children)
		    {
			    trees.Enqueue(child);
		    }
	    }

	    return result;
    }
}
