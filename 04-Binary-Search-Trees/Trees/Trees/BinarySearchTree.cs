using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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

	    Console.WriteLine("MinElement = " + current.Value);
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
        throw new NotImplementedException();
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        throw new NotImplementedException();
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
        BinarySearchTree<int> tree = new BinarySearchTree<int>();

		tree.Insert(8);
		tree.Insert(7);
		tree.Insert(3);
		tree.Insert(4);
		tree.Insert(5);
	    
		tree.DeleteMin();
	    tree.EachInOrder(x => Console.WriteLine(x));
	}
}
