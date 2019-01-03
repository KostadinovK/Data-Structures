using System;
using System.Runtime.CompilerServices;

public static class Heap<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
	    for (int i = arr.Length/2; i >= 0; i--)
	    {
		    HeapifyDown(i,arr,arr.Length);
	    }

	    int lenght = arr.Length;
	    for (int i = arr.Length - 1;i >= 1;i--)
	    {
			Swap(0,i,arr);
			HeapifyDown(0,arr,lenght-1);
		    lenght--;
	    }

    }

	private static void HeapifyDown(int index, T[] arr,int length)
	{
		int childIndex = 2 * index + 1;

		if (childIndex + 1 < length)
		{
			if (arr[childIndex].CompareTo(arr[childIndex + 1]) < 0)
			{
				childIndex++;
			}
		}

		if (childIndex < length && arr[index].CompareTo(arr[childIndex]) < 0)
		{
			Swap(index,childIndex,arr);
			HeapifyDown(childIndex,arr,length);
		}
	}

	private static void Swap(int index, int childIndex, T[] arr)
	{
		T temp = arr[index];
		arr[index] = arr[childIndex];
		arr[childIndex] = temp;
	}
}
