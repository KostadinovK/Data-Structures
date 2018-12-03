using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class ReversedList<T> : IEnumerable<T>
{ 
	private T[] data;
	private int index;
	private T _current;

	private void Resize()
	{
		T[] newArray = new T[data.Length * 2];
		Array.Copy(data,newArray,data.Length);
		data = newArray;
		index = Count - 1;
	}

	private void Shrink()
	{
		T[] newArray = new T[data.Length / 2];
		Array.Copy(data,newArray,data.Length);
		data = newArray;
	}

	public int Count { get; private set; }

	public int Capacity
	{
		get { return data.Length;}
		private set { }
	}

	public ReversedList()
	{
		data = new T[2];
		Count = 0;
		Capacity = data.Length;
	}

	public T this[int index]
	{
		get {
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException();
			}

			return data[Count - (index + 1)];
		}

		set {
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			data[Count - (index + 1)] = value;
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

	public void RemoveAt(int index)
	{
		if (index < 0 || index >= Count)
		{
			throw new ArgumentOutOfRangeException();
		}

		int ind = Count - (index + 1);

		data[ind] = default(T);
		T[] tmpArray = new T[Count-1];

		int tmpIndex = 0;
		for (int i = 0;i < ind;i++)
		{
			tmpArray[tmpIndex] = data[i];
			tmpIndex++;
		}

		for (int i = ind+1; i < Count;i++)
		{
			tmpArray[tmpIndex] = data[i];
			tmpIndex++;
		}

		data = tmpArray;
		Count--;

		if (Count <= data.Length / 4)
		{
			Shrink();
		}
	}


	public IEnumerator<T> GetEnumerator()
	{
		for (int i = Count-1;i >= 0;i--)
		{
			yield return data[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}

