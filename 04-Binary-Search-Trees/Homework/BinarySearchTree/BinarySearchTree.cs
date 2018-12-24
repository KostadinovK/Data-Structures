using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

public class BinarySearchTree<T> : IBinarySearchTree<T> where T:IComparable
{
    private Node root;

    private Node FindElement(T element)
    {
        Node current = this.root;

        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    private void PreOrderCopy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.PreOrderCopy(node.Left);
        this.PreOrderCopy(node.Right);
    }

    private Node Insert(T element, Node node)
    {
        if (node == null)
        {
            node = new Node(element);
        }
        else if (element.CompareTo(node.Value) < 0)
        {
            node.Left = this.Insert(element, node.Left);
        }
        else if (element.CompareTo(node.Value) > 0)
        {
            node.Right = this.Insert(element, node.Right);
        }

        return node;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int nodeInLowerRange = startRange.CompareTo(node.Value);
        int nodeInHigherRange = endRange.CompareTo(node.Value);

        if (nodeInLowerRange < 0)
        {
            this.Range(node.Left, queue, startRange, endRange);
        }
        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
        {
            queue.Enqueue(node.Value);
        }
        if (nodeInHigherRange > 0)
        {
            this.Range(node.Right, queue, startRange, endRange);
        }
    }
    
    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    private BinarySearchTree(Node node)
    {
        this.PreOrderCopy(node);
    }

    public BinarySearchTree()
    {
    }
    
    public void Insert(T element)
    {
        this.root = this.Insert(element, this.root);
    }
    
    public bool Contains(T element)
    {
        Node current = this.FindElement(element);

        return current != null;
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    public BinarySearchTree<T> Search(T element)
    {
        Node current = this.FindElement(element);

        return new BinarySearchTree<T>(current);
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
	        throw new InvalidOperationException("Cannot delete min node in empty tree!");
        }

        Node current = this.root;
        Node parent = null;
        while (current.Left != null)
        {
            parent = current;
            current = current.Left;
        }

        if (parent == null)
        {
            this.root = this.root.Right;
        }
        else
        {
            parent.Left = current.Right;
        }
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    public void Delete(T element)
    {
		if (Count(root) == 0 || !Contains(element))
	    {
		    throw new InvalidOperationException();
	    }
	    root = Delete(root, element);
	}
	private static Node DeleteMin(Node node)
	{
		if (node == null)
		{
			return null;
		}

		if (node.Left == null)
		{
			return node.Right;
		}

		node.Left = DeleteMin(node.Left);
		
		return node;
	}
	private Node Delete(Node node, T element)
	{
		if (node == null)
		{
			return null;
		}

		int compare = node.Value.CompareTo(element);

		if (compare > 0)
		{
			node.Left = Delete(node.Left, element);
		}
		else if (compare < 0)
		{
			node.Right = Delete(node.Right, element);
		}
		else
		{

			if (node.Left == null) return node.Right;
			if (node.Right == null) return node.Left;

			Node leftMost = node.Right;

			while (leftMost.Left != null)
			{
				leftMost = leftMost.Left;
			}


			node.Value = leftMost.Value;

			node.Right = Delete(node.Right, leftMost.Value);
		}

		return node;
	}

	public void DeleteMax()
    {
	    if (root == null)
	    {
			throw new InvalidOperationException("Cannot delete max node in empty tree!");
	    }

	    Node parent = null;
	    Node current = root;
	    while (current.Right != null)
	    {
		    parent = current;
		    current = current.Right;
	    }

	    if (parent == null)
	    {
		    this.root = this.root.Left;
		    return;
	    }

	    if (current.Left != null)
	    {
		    parent.Right = current.Left;
	    }else
	    {
		    parent.Right = null;
	    }

    }

    public int Count()
    {
	    if (root == null)
	    {
		    return 0;
	    }

	    int count = 1;
	    Queue<Node> nodes = new Queue<Node>();
		nodes.Enqueue(root);

	    Node current = null;
	    while (nodes.Count > 0)
	    {
		    current = nodes.Dequeue();
		    if (current.Left != null)
		    {
				nodes.Enqueue(current.Left);
			    count++;
		    }

		    if (current.Right != null)
		    {
				nodes.Enqueue(current.Right);
			    count++;
		    }
	    }

	    return count;
    }

	private int Count(Node node)
	{
		if (node == null)
		{
			return 0;
		}

		int count = 1;
		Queue<Node> nodes = new Queue<Node>();
		nodes.Enqueue(node);

		Node current = null;
		while (nodes.Count > 0)
		{
			current = nodes.Dequeue();
			if (current.Left != null)
			{
				nodes.Enqueue(current.Left);
				count++;
			}

			if (current.Right != null)
			{
				nodes.Enqueue(current.Right);
				count++;
			}
		}

		return count;
	}

	public int Rank(T element)
    {
	    if (root == null)
	    {
		    return 0;
	    }

	    int count = 0;

	    Queue<Node> nodes = new Queue<Node>();
		nodes.Enqueue(root);
	    Node current = null;
	    while (nodes.Count > 0)
	    {
		    current = nodes.Dequeue();
		    if (current.Value.CompareTo(element) < 0)
		    {
			    count++;
		    }

		    if (current.Left != null)
		    {
				nodes.Enqueue(current.Left);
		    }

		    if (current.Right != null)
		    {
				nodes.Enqueue(current.Right);
		    }
	    }

	    return count;
    }


	public T Select(int rank)
	{
		Node res = Select(this.root,rank);

		if (res == null)
		{
			throw new InvalidOperationException();
		}

		return res.Value;
	}

	private Node Select(Node node, int rank)
	{
		if (node == null)
		{
			return null;
		}

		int leftCount = Count(node.Left);
		if (leftCount > rank)
		{
			return Select(node.Left, rank);
		}

		if (leftCount < rank)
		{
			return Select(node.Right, rank - (leftCount + 1));
		}

		return node;
	}

	public T Ceiling(T element)
	{
		Node res = Ceiling(this.root, element);

		if (res == null)
		{
			throw new InvalidOperationException();
		}

		return res.Value;
	}

	private static Node Ceiling(Node node, T element)
	{
		if (node == null)
		{
			return null;
		}

		if (node.Value.CompareTo(element) <= 0)
		{
			return Ceiling(node.Right, element);
		}

		Node ceil = Ceiling(node.Left, element);

		if (ceil == null)
		{
			return node;
		}

		return ceil;
	}
	public T Floor(T element)
	{
		Node res = Floor(this.root,element);

		if (res == null)
		{
			throw new InvalidOperationException();
		}

		return res.Value;
	}

	private Node Floor(Node node, T element)
	{
		if (node == null)
		{
			return null;
		}

		if (node.Value.CompareTo(element) >= 0)
		{
			return Floor(node.Left, element);
		}

		Node floor = Floor(node.Right, element);

		if (floor == null)
		{
			return node;
		}

		return floor;
	}

		

	private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
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
		bst.Insert(7);
        bst.Insert(9);
        bst.Insert(37);
        bst.Insert(39);
        bst.Insert(45);
		

        bst.EachInOrder(Console.WriteLine);
	    Console.WriteLine("------------------------------");
		bst.Delete(8);
		bst.EachInOrder(Console.WriteLine);

	}
}