using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ArrayStack<T>
{
	private const int InitialCapacity = 16;

	private T[] elements;

	public int Count { get; private set; }

	private void Grow()
	{
		T[] newArr = new T[elements.Length * 2];
		Array.Copy(elements,newArr,elements.Length);
		elements = newArr;
	}

	public ArrayStack(int capacity = InitialCapacity)
	{
		elements = new T[capacity];
		Count = 0;
	}

	public void Push(T element)
	{
		if (Count >= elements.Length)
		{
			Grow();
		}

		elements[Count++] = element;

	}

	public T Pop()
	{
		if (Count == 0)
		{
			throw new InvalidOperationException("Stack is empty");
		}

		Count--;
		return elements[Count];
	}

	public T[] ToArray()
	{
		T[] res = new T[Count];
		int index = 0;
		for (int i = Count - 1;i >= 0;i--)
		{
			res[index] = elements[i];
			index++;
		}

		return res;
	}

}

