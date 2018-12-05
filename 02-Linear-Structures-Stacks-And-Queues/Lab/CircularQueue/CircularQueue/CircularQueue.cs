using System;

public class CircularQueue<T>
{
    private const int DefaultCapacity = 4;
	private int startIndex;
	private int endIndex;
	private T[] data;


	public int Count { get; private set; }

    public CircularQueue(int capacity = DefaultCapacity)
    {
		data = new T[capacity];
	    Count = 0;
	    endIndex = 0;
	    startIndex = 0;
    }

    public void Enqueue(T element)
    {

	    if (Count >= data.Length)
	    {
			Resize();
	    }
		
	    data[endIndex] = element;
		endIndex = (endIndex + 1) % data.Length;

	    Count++;

    }

    private void Resize()
    {
		T[] newArr = new T[data.Length * 2];
		CopyAllElements(newArr);
	    data = newArr;
	    startIndex = 0;
	    endIndex = Count;
    }

    private void CopyAllElements(T[] newArray)
    {
	    int start = startIndex;
	    for (int i = 0;i < Count;i++)
	    {
		    newArray[i] = data[start];
		    start = (start + 1) % data.Length;
	    }
    }

    // Should throw InvalidOperationException if the queue is empty
    public T Dequeue()
    {
	    if (Count == 0)
	    {
			throw new InvalidOperationException("The queue is empty");
	    }

	    T toRemove = data[startIndex];
	    startIndex = (startIndex + 1) % data.Length;
	    Count--;

	 
	    return toRemove;
    }

    public T[] ToArray()
    {
	    T[] arr = new T[Count];
	    int start = startIndex;
	    for (int i = 0;i < Count;i++)
	    {
		    arr[i] = data[start];
		    start = (start + 1) % data.Length;
	    }

	    return arr;
    }
}


public class Example
{
    public static void Main()
    {

        CircularQueue<int> queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        int first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
