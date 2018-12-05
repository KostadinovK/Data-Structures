using System;

class Launcher
{
    public static void Main()
    {
		LinkedList<int> nums = new LinkedList<int>();
		nums.AddFirst(3);
		nums.AddFirst(2);
		nums.AddFirst(1);
	    foreach (var num in nums)
	    {
		    Console.WriteLine(num);
	    }
    }
}
