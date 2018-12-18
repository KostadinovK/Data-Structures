using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;

public class BinarySearchTree<T> where T : IComparable<T>
{
	private class Node
	{
		public T Value { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }

		public Node(T value)
		{
			this.Value = value;
			this.Left = null;
			this.Right = null;
		}


	}

	private Node root;

	public BinarySearchTree()
	{
	}

	private BinarySearchTree(Node node)
	{
		Copy(node);
	}

	private void Copy(Node node)
	{
		if (node == null)
		{
			return;
		}


		Insert(node.Value);
		Copy(node.Left);
		Copy(node.Right);
	}

	public void Insert(T value)
	{
		if (root == null)
		{
			root = new Node(value);
		}

		Insert(root, value);
	}

	private Node Insert(Node node, T value)
	{
		if (node == null)
		{
			return new Node(value);
		}

		int compareResult = value.CompareTo(node.Value);

		if (compareResult > 0)
		{
			node.Right = Insert(node.Right,value);
		}else if (compareResult < 0)
		{
			node.Left = Insert(node.Left, value);
		}

		return node;
	}

	public bool Contains(T value)
	{
		if (root == null)
		{
			return false;
		}

		Node current = root;

		while (current != null)
		{
			int compareResult = value.CompareTo(current.Value);

			if (compareResult < 0)
			{
				current = current.Left;
			}else if (compareResult > 0)
			{
				current = current.Right;
			}
			else
			{
				return true;
			}
		}

		return false;
	}

    public void DeleteMin()
    {
	    if (root == null)
	    {
		    return;
	    }

	    if (root.Left == null && root.Right == null)
	    {
		    root = null;
		    return;
	    }

	    Node parent = null;
	    Node current = root;
	    while (current.Left != null)
	    {
		    parent = current;
		    current = current.Left;
	    }

	    if (current.Right == null)
	    {
		    parent.Left = null;
		}
	    else
	    {
		    parent.Left = current.Right;
	    }


    }

	public BinarySearchTree<T> Search(T item)
    {
	    if (root == null)
	    {
		    return null;
	    }

	    Node current = root;
	    while (current != null)
	    {
		    int compareResult = current.Value.CompareTo(item);

		    if (compareResult > 0)
		    {
			    current = current.Left;
		    }else if (compareResult < 0)
		    {
			    current = current.Right;
		    }
		    else
		    {
				return new BinarySearchTree<T>(current);
		    }
	    }

	    return null;
    }

	public IEnumerable<T> Range(T startRange, T endRange)
	{
		if (root == null)
		{
			return null;
		}

		List<T> result = new List<T>();

		Range(startRange,endRange,result,root);

		return result;
	}

	private void Range(T startRange, T endRange, List<T> result, Node node)
	{
		if (node == null)
		{
			return;
		}

		int startCompareResult = node.Value.CompareTo(startRange);
		int endCompareResult = node.Value.CompareTo(endRange);

		if (startCompareResult >= 0)
		{
			Range(startRange, endRange, result, node.Left);
		}

		

		if (startCompareResult >= 0 && endCompareResult <= 0)
		{
			result.Add(node.Value);
		}

		if (endCompareResult <= 0)
		{
			Range(startRange, endRange, result, node.Right);
		}
		
	}

	public void EachInOrder(Action<T> action)
    {
	    if (root == null)
	    {
		    return;
	    }

		EachInOrder(root, action);
    }

	private void EachInOrder(Node node, Action<T> action)
	{
		if (node == null)
		{
			return;
		}

		EachInOrder(node.Left,action);
		action(node.Value);
		EachInOrder(node.Right,action);
	}
}

public class Launcher
{
    public static void Main(string[] args)
    {
		BinarySearchTree<int> bst = new BinarySearchTree<int>();

	    bst.Insert(10);
	    bst.Insert(5);
	    bst.Insert(3);
	    bst.Insert(1);
	    bst.Insert(4);
	    bst.Insert(8);
	    bst.Insert(9);
	    bst.Insert(37);
	    bst.Insert(39);
	    bst.Insert(45);

	    var nums = bst.Range(4, 37);

	    foreach (var num in nums)
	    {
		    Console.WriteLine("------" + num + "----");
	    }
    }
}
