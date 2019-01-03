using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> heap;

    public BinaryHeap()
    {
        heap = new List<T>();
    }

    public int Count
    {
        get
        {
            return heap.Count;
        }
    }

    public void Insert(T item)
    {
        this.heap.Add(item);
	    this.HeapifyUp(this.Count - 1);
    }

	private void HeapifyUp(int index)
	{
		int parentIndex = (index - 1) / 2;
		int compare = this.heap[parentIndex].CompareTo(this.heap[index]);

		if (parentIndex >= 0 && compare < 0)
		{
			this.Swap(index,parentIndex);
			this.HeapifyUp(parentIndex);
		}
	}

	private void Swap(int index, int parentIndex)
	{
		T temp = this.heap[index];
		this.heap[index] = this.heap[parentIndex];
		this.heap[parentIndex] = temp;
	}

	public T Peek()
    {
	    if (Count == 0)
	    {
			throw new InvalidOperationException();
	    }

	    return this.heap[0];
    }

    public T Pull()
    {
	    if (this.Count == 0)
	    {
			throw new InvalidOperationException();
	    }

	    T element = this.heap[0];
	    this.Swap(0, this.Count - 1);
	    this.heap.RemoveAt(this.Count - 1);
	    this.HeapifyDown(0);

	    return element;
    }

	private void HeapifyDown(int index)
	{
		int childIndex = 2 * index + 1;

		if (childIndex + 1 < this.Count)
		{
			if (this.heap[childIndex].CompareTo(this.heap[childIndex+1]) < 0)
			{
				childIndex++;
			}
		}

		if (childIndex < this.heap.Count && this.heap[index].CompareTo(this.heap[childIndex]) < 0)
		{
			this.Swap(index,childIndex);
			this.HeapifyDown(childIndex);
		}
	}
}
