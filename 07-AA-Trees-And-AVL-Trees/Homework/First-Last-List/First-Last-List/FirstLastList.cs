﻿using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T> where T : IComparable<T>
{
    private LinkedList<T> byInsertion;
    private OrderedBag<LinkedListNode<T>> byAscending;
    private OrderedBag<LinkedListNode<T>> byDescending;

    public FirstLastList()
    {
        byInsertion = new LinkedList<T>();
        byAscending = new OrderedBag<LinkedListNode<T>>((x,y) => x.Value.CompareTo(y.Value));
        byDescending = new OrderedBag<LinkedListNode<T>>((x,y) => y.Value.CompareTo(x.Value));
    }

    public int Count
    {
        get
        {
            return byInsertion.Count;
        }
    }

    public void Add(T element)
    {
        LinkedListNode<T> node = new LinkedListNode<T>(element);
        byInsertion.AddLast(node);
        byAscending.Add(node);
        byDescending.Add(node);
    }

    public void Clear()
    {
        byInsertion.Clear();
        byAscending.Clear();
        byDescending.Clear();
    }

    public IEnumerable<T> First(int count)
    {
        if (count > byInsertion.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        LinkedListNode<T> current = this.byInsertion.First;

        int iters = 0;
        while (iters < count)
        {
            yield return current.Value;
            current = current.Next;
            iters++;
        }
    }

    public IEnumerable<T> Last(int count)
    {
        if (count > byInsertion.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        LinkedListNode<T> current = this.byInsertion.Last;

        int iters = 0;
        while (iters < count)
        {
            yield return current.Value;
            current = current.Previous;
            iters++;
        }
    }

    public IEnumerable<T> Max(int count)
    {
        if (count > byInsertion.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return byDescending.Take(count).Select(x => x.Value);

    }

    public IEnumerable<T> Min(int count)
    {
        if (count > byInsertion.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return byAscending.Take(count).Select(x => x.Value);
    }

    public int RemoveAll(T element)
    {
        LinkedListNode<T> node = new LinkedListNode<T>(element);
        foreach (var item in this.byAscending.Range(node, true, node, true))
        {
            this.byInsertion.Remove(item);
        }

        int count = this.byAscending.RemoveAllCopies(node);
        this.byDescending.RemoveAllCopies(node);
        return count;
    }
}
