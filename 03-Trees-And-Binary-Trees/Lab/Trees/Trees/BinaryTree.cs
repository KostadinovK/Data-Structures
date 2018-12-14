using System;

public class BinaryTree<T>
{
	public T Value { get; private set; }
	public BinaryTree<T> Left { get; private set; }
	public BinaryTree<T> Right { get; private set; }

	public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
	{
		this.Value = value;
		this.Left = leftChild;
		this.Right = rightChild;
	}

    public void PrintIndentedPreOrder(int indent = 0)
    {
        PrintIndentedPreOrder(this,indent);
    }

	private void PrintIndentedPreOrder(BinaryTree<T> tree, int indent)
	{
		if (tree == null)
		{
			return;
		}

		Console.WriteLine($"{new string(' ',indent)}{tree.Value}");
		PrintIndentedPreOrder(tree.Left,indent+2);
		PrintIndentedPreOrder(tree.Right,indent+2);
	}

	public void EachInOrder(Action<T> action)
    {
		EachInOrder(this,action);    
    }

	private void EachInOrder(BinaryTree<T> current, Action<T> action)
	{
		if (current == null)
		{
			return;
		}

		EachInOrder(current.Left,action);
		action(current.Value);
		EachInOrder(current.Right,action);
	}

	public void EachPostOrder(Action<T> action)
    {
        EachPostOrder(this,action);
    }

	private void EachPostOrder(BinaryTree<T> current, Action<T> action)
	{
		if (current == null)
		{
			return;
		}

		EachPostOrder(current.Left, action);
		EachPostOrder(current.Right,action);
		action(current.Value);
	}
}
