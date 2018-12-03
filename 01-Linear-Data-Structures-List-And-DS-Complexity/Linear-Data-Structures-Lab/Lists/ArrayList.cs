using System;

public class ArrayList<T>
{
	private T[] data;

	private void Resize()
	{
		T[] newArray = new T[data.Length * 2];
		Array.Copy(data,newArray,data.Length);
		data = newArray;
	}

	private void Shrink()
	{
		T[] newArray = new T[data.Length/2];
		Array.Copy(data,newArray,Count);
		data = newArray;
	}

	private void Shift(int index)
	{
		for (int i = index; i < Count; i++)
		{
			data[i] = data[i + 1];
		}
	}

	public int Count { get; private set; }

	public ArrayList()
	{
		data = new T[2];
		Count = 0;
	}

	public T this[int index]
    {
        get
        {
	        if (index < 0 || index >= Count)
	        {
				throw new ArgumentOutOfRangeException();
	        }

	        return data[index];
        }

        set
        {
	        if (index < 0 || index >= Count)
	        {
		        throw new ArgumentOutOfRangeException();
	        }
			data[index] = value;
        }
    }

    public void Add(T item)
    {
	    if (Count >= data.Length)
	    {
		    Resize();
	    }

	    data[Count++] = item;
    }

    public T RemoveAt(int index)
    {
	    if (index < 0 || index >= Count)
	    {
		    throw new ArgumentOutOfRangeException();
	    }

	    T elementToRemove = data[index];
	    data[index] = default(T);
	    Shift(index);
	    Count--;
	    if (data.Length / 4 >= Count)
	    {
		    Shrink();
	    }

	    return elementToRemove;
    }
}
