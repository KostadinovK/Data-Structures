using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

public class LinkedStack<T>
{
	private class Node
	{
		public T Value { get; private set; }
		public Node Next { get; set; }

		public Node(T value, Node next = null)
		{
			this.Value = value;
			this.Next = next;
		}
	}

	private Node firstNode;

	public int Count { get; private set; }

	public LinkedStack()
	{
		firstNode = null;
		Count = 0;
	}

	public void Push(T element)
	{
		if (Count == 0)
		{
			firstNode = new Node(element);
		}
		else
		{
			Node newFirst = new Node(element);
			newFirst.Next = firstNode;
			firstNode = newFirst;
		}

		Count++;
	}

	public T Pop()
	{
		if (Count == 0)
		{
			throw new InvalidOperationException("Stack is empty");
		}

		T toRemove = firstNode.Value;

		if (Count == 1)
		{

			firstNode = null;
		}
		else
		{
			firstNode = firstNode.Next;
		}

		Count--;
		return toRemove;
	}

	public T[] ToArray()
	{
		T[] arr = new T[Count];
		Node current = firstNode;
		int index = 0;
		while (current != null)
		{
			arr[index] = current.Value;
			current = current.Next;
			index++;
		}

		return arr;
	}

}
