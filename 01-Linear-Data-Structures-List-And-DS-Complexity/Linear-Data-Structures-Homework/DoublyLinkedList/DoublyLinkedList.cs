using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
	private class Node<T>
	{
		public Node<T> Previous { get; set; }
		public T Value { get; set; }
		public Node<T> Next { get; set; }

		public Node(T value)
		{
			Value = value;
			Previous = null;
			Next = null;
		}
	}

	private Node<T> head;
	private Node<T> tail;

	public int Count { get; private set; }

    public void AddFirst(T element)
    {
	    if (Count == 0)
	    {
		    head = tail = new Node<T>(element);
	    }
	    else
	    {
		    Node<T> newHead = new Node<T>(element);
		    newHead.Next = head;
		    head.Previous = newHead;
		    head = newHead;
	    }

	    Count++;
    }

    public void AddLast(T element)
    {
	    if (Count == 0)
	    {
		    head = tail = new Node<T>(element);
	    }
	    else
	    {
		    Node<T> newTail = new Node<T>(element);
			newTail.Previous = tail;
		    tail.Next = newTail;
		    tail = newTail;
	    }

	    Count++;
    }

    public T RemoveFirst()
    {
	    if (Count == 0)
	    {
		    throw new InvalidOperationException("List empty");
	    }

	    T valueToRemove = head.Value;
	    head = head.Next;
	    if (head != null)
	    {
		    head.Previous = null;
		}
	    else
	    {
		    tail = null;
	    }


	    Count--;

	    return valueToRemove;
    }

    public T RemoveLast()
    {
		if (Count == 0)
	    {
		    throw new InvalidOperationException("List empty");
	    }

	    T valueToRemove = tail.Value;
	    tail = tail.Previous;
	    if (tail != null)
	    {
		    tail.Next = null;
	    }
	    else
	    {
		    head = null;
	    }


	    Count--;

	    return valueToRemove;
	}

    public void ForEach(Action<T> action)
    {
	    while (head != null)
	    {
		    action(head.Value);
		    head = head.Next;
	    }
    }

    public IEnumerator<T> GetEnumerator()
    {
	    while (head != null)
	    {
		    yield return head.Value;
		    head = head.Next;
	    }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
	    return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] array = new T[Count];
	    int index = 0;
	    while (head != null)
	    {
		    array[index] = head.Value;
		    index++;
		    head = head.Next;
	    }

	    return array;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
