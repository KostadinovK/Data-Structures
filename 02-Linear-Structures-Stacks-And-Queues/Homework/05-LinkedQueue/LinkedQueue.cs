using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LinkedQueue<T>
{
	private class Node
	{
		public T Value { get; set; }
		public Node Next { get; set; }

		public Node(T value, Node next = null)
		{
			Value = value;
			Next = next;
		}
	}

	private Node head;
	private Node tail;

	public int Count { get; private set; }

	public LinkedQueue()
	{
		head = tail = null;
		Count = 0;
	}

	public void Enqueue(T element)
	{
		Node newTail = new Node(element);
		if (Count == 0)
		{
			head = tail = newTail;
		}
		else if(Count == 1)
		{
			
			head.Next = newTail;
			tail.Next = newTail;
			tail = newTail;
		}
		else
		{
			tail.Next = newTail;
			tail = newTail;
		}

		Count++;
	}

	public T Dequeue()
	{
		if (Count == 0)
		{
			throw new InvalidOperationException("Queue is empty");
		}

		T toRemove = head.Value;
		if (Count == 1)
		{
			head = tail = null;
		}
		else
		{
			head = head.Next;
		}

		Count--;
		return toRemove;
	}

	public T[] ToArray()
	{
		T[] arr = new T[Count];
		int index = 0;
		Node current = head;
		while (current != null)
		{
			arr[index] = current.Value;
			index++;
			current = current.Next;
		}

		return arr;
	}

}
