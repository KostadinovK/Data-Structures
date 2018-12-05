using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
	private class Node
	{
		public T Value { get; set; }
		public Node Next { get; set; }

		public Node(T value)
		{
			Value = value;
			Next = null;
		}
	}

	private Node head;
	private Node tail;
	public int Count { get; private set; }

    public void AddFirst(T item)
    {
	    Node newHead = new Node(item);
	    if (Count == 0)
	    {
		    head = tail = newHead;
	    }
	    else
	    {
		    newHead.Next = head;
		    head = newHead;
		}
		Count++;
    }

    public void AddLast(T item)
    {
		Node newTail = new Node(item);
	    if (Count == 0)
	    {
		    head = tail = newTail;
	    }
	    else
	    {
		    tail.Next = newTail;
		    tail = newTail;
	    }

	    Count++;
    }

    public T RemoveFirst()
    {
	    if (Count == 0)
	    {
			throw new InvalidOperationException();
	    }

	    Node oldHead = head;

	    if (Count == 1)
	    {
		    head = tail = null;
	    }
	    else
	    {
		    head = head.Next;
		    oldHead.Next = null;
	    }

	    Count--;

	    return oldHead.Value;
    }

    public T RemoveLast()
    {
	    if (Count == 0)
	    {
			throw new InvalidOperationException();
	    }

	    Node oldTail = tail;

	    if (Count == 1)
	    {
		    head = tail = null;
	    }
	    else
	    {
		    Node current = head;
		    while (current.Next != tail)
		    {
			    current = current.Next;
		    }

		    tail = current;
	    }

	    Count--;
	    return oldTail.Value;
    }

    public IEnumerator<T> GetEnumerator()
    {
	    Node current = head;
	    while (current != null)
	    {
		    yield return current.Value;
		    current = current.Next;
	    }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
	    return this.GetEnumerator();
    }
}
